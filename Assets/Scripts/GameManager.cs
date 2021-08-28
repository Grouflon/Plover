using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public struct ParallaxObjectEntry
{
    public string name;
    public Transform prefab;
}

public class GameManager : MonoBehaviour
{
    [Header("Gameplay")]
    public float timeBetweenLines = 0.1f;

    [Header("Internal")]
    public TextAsset inkAsset;
    public ParallaxController parallaxController;
    public Animator scene;
    public LineController linePrefab;
    public Transform ploverLineTransform;

    void Start()
    {
        m_story = new Story(inkAsset.text);
        m_story.BindExternalFunction("setParallaxSpeed", (float _speed) =>
        {
            parallaxController.speed = _speed;
        });
        m_story.BindExternalFunction("playAnimation", (string _animationName) =>
        {
            scene.Play(_animationName);
        });
        m_story.BindExternalFunction("waitForAnimationEnd", () =>
        {
            m_waitForAnimationEnd = true;
        });

        StartCoroutine(onAdvanceStory());
    }

    void Update()
    {
        if (m_isWaitingForInteraction && m_story.canContinue)
        {
            if (Input.anyKey)
            {
                StartCoroutine(onAdvanceStory());
            }
        }
    }

    IEnumerator onAdvanceStory()
    {
        m_isWaitingForInteraction = false;

        if (m_currentLine)
        {
            yield return StartCoroutine(hideLine());
        }

        if(m_story.canContinue)
        {
            string line = m_story.Continue();

            // waitForAnimationEnd
            if (m_waitForAnimationEnd)
            {
                while(isAnimationPlaying())
                {
                    yield return new WaitForEndOfFrame();
                }
                m_waitForAnimationEnd = false;
            }

            yield return StartCoroutine(displayLine(line));

            // Turns
            Debug.Log("Turn: " + m_turnCount);
            ++m_turnCount;
        }

        m_isWaitingForInteraction = true;

        yield return null;
    }

    IEnumerator displayLine(string _line)
    {
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

    bool isAnimationPlaying()
    {
        //Debug.Log(scene.GetCurrentAnimatorStateInfo(0).length);
        //Debug.Log(scene.GetCurrentAnimatorStateInfo(0).normalizedTime);
        return scene.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0 || scene.IsInTransition(0);
        //return scene.GetCurrentAnimatorStateInfo(0).length > scene.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    Story m_story;
    int m_turnCount = 0;

    bool m_waitForAnimationEnd = false;
    bool m_isWaitingForInteraction = false;

    LineController m_currentLine;
}
