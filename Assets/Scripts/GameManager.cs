using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.Assertions;

public enum InkEventType
{
    setParallaxSpeed,
    playAnimation,
    waitForAnimationEnd,
    waitForSeconds,
}

public class InkEvent
{
    public InkEvent(InkEventType _type)
    {
        type = _type;
    }

    public InkEventType type;
};

public class SetParallaxSpeed_InkEvent : InkEvent
{
    public SetParallaxSpeed_InkEvent(float _speed) : base(InkEventType.setParallaxSpeed)
    {
        speed = _speed;
    }
    public float speed;
}

public class PlayAnimation_InkEvent : InkEvent
{
    public PlayAnimation_InkEvent(AnimationController _target, string _animationName) : base(InkEventType.playAnimation)
    {
        Assert.IsNotNull(_target);

        target = _target;
        animationName = _animationName;
        delay = 0.0f;
    }

    public PlayAnimation_InkEvent(AnimationController _target, string _animationName, float _delay) : base(InkEventType.playAnimation)
    {
        Assert.IsNotNull(_target);

        target = _target;
        animationName = _animationName;
        delay = _delay;
    }
    public AnimationController target;
    public string animationName;
    public float delay;
}

public class WaitForAnimationEnd_InkEvent : InkEvent
{
    public WaitForAnimationEnd_InkEvent() : base(InkEventType.waitForAnimationEnd)
    {
    }
}

public class WaitForSeconds_InkEvent : InkEvent
{
    public WaitForSeconds_InkEvent(float _time) : base(InkEventType.waitForSeconds)
    {
        time = _time;
    }
    public float time;
}

public struct DelayedAnimation
{
    public AnimationController target;
    public float delay;
    public string animationName;
}

public class GameManager : MonoBehaviour
{
    [Header("Gameplay")]
    public float timeBetweenLines = 0.1f;

    [Header("Internal")]
    public TextAsset inkAsset;
    public ParallaxController parallaxController;
    public AnimationController scene;
    public AnimationController plover;
    public LineController linePrefab;
    public Transform ploverLineTransform;

    void Start()
    {
        m_eventsPile = new List<InkEvent>();
        m_delayedAnimations = new List<DelayedAnimation>();
        
        m_story = new Story(inkAsset.text);
        m_story.BindExternalFunction("setParallaxSpeed", (float _speed) =>
        {
            Debug.Log(string.Format("Ink: setParallaxSpeed({0})", _speed));
            pushInkEvent(new SetParallaxSpeed_InkEvent(_speed));
        });
        m_story.BindExternalFunction("playAnimation", (string _target, string _animationName) =>
        {
            Debug.Log(string.Format("Ink: playAnimation({0}, {1})", _target, _animationName));
            pushInkEvent(new PlayAnimation_InkEvent(targetNameToTarget(_target), _animationName));
        });
        m_story.BindExternalFunction("playAnimationDelayed", (string _target, string _animationName, float _duration) =>
        {
            Debug.Log(string.Format("Ink: playAnimationDelayed({0}, {1})", _target, _animationName, _duration));
            pushInkEvent(new PlayAnimation_InkEvent(targetNameToTarget(_target), _animationName, _duration));
        });
        m_story.BindExternalFunction("waitForAnimationEnd", () =>
        {
            Debug.Log("Ink: waitForAnimationEnd");
            pushInkEvent(new WaitForAnimationEnd_InkEvent());
        });
        m_story.BindExternalFunction("waitForSeconds", (float _time) =>
        {
            Debug.Log(string.Format("Ink: waitForSeconds({0})", _time));
            pushInkEvent(new WaitForSeconds_InkEvent(_time));
        });

        StartCoroutine(onAdvanceStory());
    }

    void Update()
    {
        for (int i = 0; i < m_delayedAnimations.Count;)
        {
            DelayedAnimation delayedAnimation = m_delayedAnimations[i];
            delayedAnimation.delay -= Time.deltaTime;
            if (delayedAnimation.delay <= 0.0f)
            {
                delayedAnimation.target.playAnimation(delayedAnimation.animationName);
                m_delayedAnimations.RemoveAt(i);
            }
            else
            {
                m_delayedAnimations[i] = delayedAnimation;
                ++i;
            }
        }

        if (m_isWaitingForInteraction && m_story.canContinue)
        {
            if (Input.anyKeyDown)
            {
                StartCoroutine(onAdvanceStory());
            }
        }
    }

    IEnumerator onAdvanceStory()
    {
        m_isWaitingForInteraction = false;

        // Apply all pending delayed animations
        for (int i = 0; i < m_delayedAnimations.Count;)
        {
            DelayedAnimation delayedAnimation = m_delayedAnimations[i];
            delayedAnimation.target.playAnimation(delayedAnimation.animationName);
        }
        m_delayedAnimations.Clear();

        if (m_currentLine)
        {
            yield return StartCoroutine(hideLine());
        }

        if(m_story.canContinue)
        {
            string line = m_story.Continue();

            while (m_eventsPile.Count > 0)
            {
                InkEvent e = m_eventsPile[0];
                m_eventsPile.RemoveAt(0);

                switch(e.type)
                {
                    case InkEventType.setParallaxSpeed:
                    {
                        SetParallaxSpeed_InkEvent evt = (SetParallaxSpeed_InkEvent)e;
                        parallaxController.speed = evt.speed;
                    }
                    break;

                    case InkEventType.playAnimation:
                    {
                        PlayAnimation_InkEvent evt = (PlayAnimation_InkEvent)e;
                        if (evt.delay == 0.0f)
                        {
                            evt.target.playAnimation(evt.animationName);
                        }
                        else
                        {
                            pushDelayedAnimation(evt.target, evt.animationName, evt.delay);
                        }
                    }
                    break;

                    case InkEventType.waitForAnimationEnd:
                    {
                        WaitForAnimationEnd_InkEvent evt = (WaitForAnimationEnd_InkEvent)e;
                        while(scene.isAnimationPlaying())
                        {
                            yield return new WaitForEndOfFrame();
                        }
                    }
                    break;

                    case InkEventType.waitForSeconds:
                    {
                        WaitForSeconds_InkEvent evt = (WaitForSeconds_InkEvent)e;
                        yield return new WaitForSeconds(evt.time);
                    }
                    break;
                }
            }

            yield return StartCoroutine(displayLine(line));

            Debug.Log("Turn: " + m_turnCount);
            ++m_turnCount;
        }

        m_isWaitingForInteraction = true;

        yield return null;
    }

    IEnumerator displayLine(string _line)
    {
        _line = _line.Replace("<br/>", "\n");
        // Display Line
        m_currentLine = GameObject.Instantiate<LineController>(linePrefab, ploverLineTransform);
        m_currentLine.setText(_line);
        m_currentLine.show();

        yield return new WaitUntil(() => m_currentLine.getState() == LineDisplayState.Displayed);

        Debug.Log(_line);

        yield return null;
    }

    IEnumerator hideLine()
    {
        m_currentLine.hide();
        yield return new WaitForSeconds(timeBetweenLines);
        yield return null;
    }

    void pushInkEvent(InkEvent _event)
    {
        m_eventsPile.Add(_event);
    }

    void pushDelayedAnimation(AnimationController _target, string _animationName, float _delay)
    {
        DelayedAnimation delayedAnimation;
        delayedAnimation.target = _target;
        delayedAnimation.delay = _delay;
        delayedAnimation.animationName = _animationName;
        m_delayedAnimations.Add(delayedAnimation);
    }

    AnimationController targetNameToTarget(string _targetName)
    {
        switch(_targetName)
        {
            case "scene": return scene;
            case "plover" : return plover;
            default : return null;
        }
    }

    Story m_story;
    int m_turnCount = 0;

    bool m_isWaitingForInteraction = false;

    LineController m_currentLine;
    List<InkEvent> m_eventsPile;
    List<DelayedAnimation> m_delayedAnimations;
}
