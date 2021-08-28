using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.Assertions;

public enum InkEventType
{
    setParallaxSpeed,
    playAnimation,
    autoPassLine,
    clearAllLines,
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

public class ClearAllLines_InkEvent : InkEvent
{
    public ClearAllLines_InkEvent() : base(InkEventType.clearAllLines)
    {
    }
}

public class AutoPassLine_InkEvent : InkEvent
{
    public AutoPassLine_InkEvent(float _delay) : base(InkEventType.autoPassLine)
    {
        delay = _delay;
    }
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

[System.Serializable]
public struct CharacterDefinition
{
    public string name;
    public Color color;
    public Transform lineTransform;
    public AnimationController animation;
}

public class GameManager : MonoBehaviour
{
    [Header("Gameplay")]
    public float timeBetweenLines = 0.1f;
    public List<CharacterDefinition> characters;

    [Header("Internal")]
    public TextAsset inkAsset;
    public ParallaxController parallaxController;
    public LineController linePrefab;

    void Start()
    {
        m_characters = new Dictionary<string, CharacterDefinition>();
        foreach(var c in characters)
        {
            m_characters.Add(c.name, c);
        }
        m_eventsPile = new List<InkEvent>();
        m_delayedAnimations = new List<DelayedAnimation>();
        m_currentLines = new Dictionary<string, LineController>();

        m_story = new Story(inkAsset.text);
        m_story.BindExternalFunction("setParallaxSpeed", (float _speed) =>
        {
            Debug.Log(string.Format("Ink: setParallaxSpeed({0})", _speed));
            pushInkEvent(new SetParallaxSpeed_InkEvent(_speed));
        });
        m_story.BindExternalFunction("playAnimation", (string _target, string _animationName) =>
        {
            Debug.Log(string.Format("Ink: playAnimation({0}, {1})", _target, _animationName));
            pushInkEvent(new PlayAnimation_InkEvent(targetNameToDefinition(_target).animation, _animationName));
        });
        m_story.BindExternalFunction("playAnimationDelayed", (string _target, string _animationName, float _duration) =>
        {
            Debug.Log(string.Format("Ink: playAnimationDelayed({0}, {1})", _target, _animationName, _duration));
            pushInkEvent(new PlayAnimation_InkEvent(targetNameToDefinition(_target).animation, _animationName, _duration));
        });
        m_story.BindExternalFunction("clearAllLines", () =>
        {
            Debug.Log(string.Format("Ink: clearAllLines"));
            pushInkEvent(new ClearAllLines_InkEvent());
        });
        m_story.BindExternalFunction("autoPassLine", (float _delay) =>
        {
            Debug.Log(string.Format("Ink: autoPassLine({0})", _delay));
            pushInkEvent(new AutoPassLine_InkEvent(_delay));
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


        if (m_autoPassNextLineTimer >= 0.0f)
        {
            m_autoPassNextLineTimer -= Time.deltaTime;
            if (m_autoPassNextLineTimer <= 0.0f)
            {
                m_autoPassNextLineTimer = -1.0f;
                StartCoroutine(onAdvanceStory());
            }
        }
        else
        {
            if (m_isWaitingForInteraction && m_lastDisplayedLine != null)
            {
                m_lastDisplayedLine.setBlinkerEnabled(true);
            }

            if (m_isWaitingForInteraction && m_story.canContinue)
            {
                if (Input.anyKeyDown)
                {
                    StartCoroutine(onAdvanceStory());
                }
            }
        }
    }

    IEnumerator onAdvanceStory()
    {
        Assert.IsTrue(m_story.canContinue);

        m_isWaitingForInteraction = false;

        if (m_lastDisplayedLine != null)
        {
            m_lastDisplayedLine.setBlinkerEnabled(false);
        }

        string line = m_story.Continue();

        string target = "plover";
        if (m_story.currentTags.Count > 0)
        {
            target = m_story.currentTags[0];
        }

        // Apply all pending delayed animations
        for (int i = 0; i < m_delayedAnimations.Count; ++i)
        {
            DelayedAnimation delayedAnimation = m_delayedAnimations[i];
            delayedAnimation.target.playAnimation(delayedAnimation.animationName);
        }
        m_delayedAnimations.Clear();

        // Consume clearAllLinesEvents first
        for (int i = 0; i < m_eventsPile.Count;)
        {
            if (m_eventsPile[i].type == InkEventType.clearAllLines)
            {
                foreach(var pair in m_currentLines)
                {
                    pair.Value.hide();
                }
                m_currentLines.Clear();
                m_eventsPile.RemoveAt(i);
                yield return new WaitForSeconds(timeBetweenLines);
            }
            else
            {
                ++i;
            }
        }

        yield return StartCoroutine(hideLine(target));

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

                case InkEventType.autoPassLine:
                {
                    AutoPassLine_InkEvent evt = (AutoPassLine_InkEvent)e;
                    m_autoPassNextLineTimer = evt.delay;
                }
                break;

                case InkEventType.waitForAnimationEnd:
                {
                    WaitForAnimationEnd_InkEvent evt = (WaitForAnimationEnd_InkEvent)e;
                    while(targetNameToDefinition("scene").animation.isAnimationPlaying())
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

        yield return StartCoroutine(displayLine(line, target));

        Debug.Log("Turn: " + m_turnCount);
        ++m_turnCount;

        m_isWaitingForInteraction = true;

        yield return null;
    }

    IEnumerator displayLine(string _line, string _target)
    {
        Assert.IsFalse(m_currentLines.ContainsKey(_target));

        _line = _line.Replace("<br/>", "\n");
        CharacterDefinition c = targetNameToDefinition(_target);
        // Display Line
        LineController currentLine = GameObject.Instantiate<LineController>(linePrefab, c.lineTransform);
        currentLine.setText(_line);
        currentLine.setColor(c.color);
        currentLine.show();
        m_currentLines.Add(_target, currentLine);
        m_lastDisplayedLine = currentLine;

        yield return new WaitUntil(() => currentLine.getState() == LineDisplayState.Displayed);

        Debug.Log(_line);

        yield return null;
    }

    IEnumerator hideLine(string _target)
    {
        if (m_currentLines.ContainsKey(_target))
        {
            m_currentLines[_target].hide();
            m_currentLines.Remove(_target);
            yield return new WaitForSeconds(timeBetweenLines);
        }
        
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

    CharacterDefinition targetNameToDefinition(string _targetName)
    {
        Assert.IsTrue(m_characters.ContainsKey(_targetName));
        return m_characters[_targetName];
    }

    Story m_story;
    int m_turnCount = 0;

    bool m_isWaitingForInteraction = false;
    float m_autoPassNextLineTimer = -1.0f;

    Dictionary<string, LineController> m_currentLines;
    LineController m_lastDisplayedLine;
    List<InkEvent> m_eventsPile;
    List<DelayedAnimation> m_delayedAnimations;
    Dictionary<string, CharacterDefinition> m_characters;
}
