using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.Assertions;

public enum InkEventType
{
    setParallaxSpeed,
    setDayTime,
    playAnimation,
    setHorizontalPosition,
    autoPassLine,
    clearAllLines,
    waitForAnimationEnd,
    waitForSeconds,
    fadeAudio,
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

public class SetDayTime_InkEvent : InkEvent
{
    public SetDayTime_InkEvent(string _dayTimeName) : base(InkEventType.setDayTime)
    {
        dayTimeName = _dayTimeName;
    }
    public string dayTimeName;
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

public class SetHorizontalPosition_InkEvent : InkEvent
{
    public SetHorizontalPosition_InkEvent(string _target, float _position) : base(InkEventType.setHorizontalPosition)
    {
        target = _target;
        position = _position;
    }
    public string target;
    public float position;
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
    public WaitForAnimationEnd_InkEvent(string _target) : base(InkEventType.waitForAnimationEnd)
    {
        target = _target;
    }
    public string target;
}

public class WaitForSeconds_InkEvent : InkEvent
{
    public WaitForSeconds_InkEvent(float _time) : base(InkEventType.waitForSeconds)
    {
        time = _time;
    }
    public float time;
}

public class FadeAudio_InkEvent : InkEvent
{
    public FadeAudio_InkEvent(string _name, float _target, float _time) : base(InkEventType.fadeAudio)
    {
        name = _name;
        target = _target;
        time = _time;
    }
    public string name;
    public float target;
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
    public LineController linePrefabVariant;
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
    public DayTimeController dayTimeController;
    public GameObject dummyBlackout;
    public AudioController dayBGM;
    public AudioController nightBGM;
    public AudioController footstepsBGM;

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
        m_story.BindExternalFunction("setDayTime", (string _dayTimeName) =>
        {
            Debug.Log(string.Format("Ink: setDayTime({0})", _dayTimeName));
            pushInkEvent(new SetDayTime_InkEvent(_dayTimeName));
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
        m_story.BindExternalFunction("setHorizontalPosition", (string _target, float _position) =>
        {
            Debug.Log(string.Format("Ink: setHorizontalPosition({0}, {1})", _target, _position));
            pushInkEvent(new SetHorizontalPosition_InkEvent(_target, _position));
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
        m_story.BindExternalFunction("waitForAnimationEnd", (string _target) =>
        {
            Debug.Log(string.Format("Ink: waitForAnimationEnd({0})", _target));
            pushInkEvent(new WaitForAnimationEnd_InkEvent(_target));
        });
        m_story.BindExternalFunction("waitForSeconds", (float _time) =>
        {
            Debug.Log(string.Format("Ink: waitForSeconds({0})", _time));
            pushInkEvent(new WaitForSeconds_InkEvent(_time));
        });
        m_story.BindExternalFunction("fadeAudio", (string _name, float _target, float _time) =>
        {
            Debug.Log(string.Format("Ink: fadeAudio({0}, {1}, {2})", _name, _target, _time));
            pushInkEvent(new FadeAudio_InkEvent(_name, _target, _time));
        });

        StartCoroutine(onAdvanceStory());
    }

    void Update()
    {
#if UNITY_WEBGL == false
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            return;
        }
#endif

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

        if (dummyBlackout != null)
        {
            yield return new WaitForEndOfFrame();
            GameObject.Destroy(dummyBlackout);
        }

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
        /*for (int i = 0; i < m_delayedAnimations.Count; ++i)
        {
            DelayedAnimation delayedAnimation = m_delayedAnimations[i];
            delayedAnimation.target.playAnimation(delayedAnimation.animationName);
        }
        m_delayedAnimations.Clear();*/

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

                case InkEventType.setDayTime:
                {
                    SetDayTime_InkEvent evt = (SetDayTime_InkEvent)e;
                    dayTimeController.setDayTime(evt.dayTimeName);
                }
                break;

                case InkEventType.playAnimation:
                {
                    PlayAnimation_InkEvent evt = (PlayAnimation_InkEvent)e;
                        if (evt.delay == 0.0f)
                        {
                            evt.target.playAnimation(evt.animationName);

                            // Clear delayed animations still pending
                            for (int i = 0; i < m_delayedAnimations.Count;)
                            {
                                if (evt.target != m_delayedAnimations[i].target)
                                {
                                    ++i;
                                    continue;
                                }

                                m_delayedAnimations.RemoveAt(i);
                            }
                        }
                        else
                        {
                            pushDelayedAnimation(evt.target, evt.animationName, evt.delay);
                        }
                }
                break;

                case InkEventType.setHorizontalPosition:
                {
                    SetHorizontalPosition_InkEvent evt = (SetHorizontalPosition_InkEvent)e;
                    CharacterDefinition d = targetNameToDefinition(evt.target);
                    if (d.animation != null)
                    {
                        Vector3 position = d.animation.transform.localPosition;
                        position.x = evt.position;
                        d.animation.transform.localPosition = position;
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
                    while(targetNameToDefinition(evt.target).animation.isAnimationPlaying())
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

                case InkEventType.fadeAudio:
                {
                    FadeAudio_InkEvent evt = (FadeAudio_InkEvent)e;
                    fadeSound(evt.name, evt.target, evt.time);
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
        LineController prefab = c.linePrefabVariant;
        if (prefab == null)
            prefab = linePrefab;

        // Display Line
        LineController currentLine = GameObject.Instantiate<LineController>(prefab, c.lineTransform);
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

    public void fadeSound(string _name, float _target, float _time)
    {
        switch(_name)
        {
            case "day":
            {
                dayBGM.fadeAudio(_target, _time);
            }
            break;

            case "night":
            {
                nightBGM.fadeAudio(_target, _time);
            }
            break;

            case "footsteps":
            {
                footstepsBGM.fadeAudio(_target, _time);
            }
            break;
        }
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
