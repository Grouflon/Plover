using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using grouflon;

public enum LineDisplayState
{
    Hidden,
    Entering,
    Displayed,
    Exiting,
}

public class LineController : MonoBehaviour
{
    [Header("Gameplay")]
    public float enterTravelLength = 0.6f;
    public float exitTravelLength = 1.5f;
    public float enterAnimationLength = 1.5f;
    public float exitAnimationLength = 1.5f;

    [Header("Internal")]
    public TextMeshPro text;
    public Blinker blinker;
    public float baseLineOffset = 1.0f;
    public float lineHeight = 1.0f;

    void Start()
    {
        blinker.gameObject.SetActive(false);
    }

    void Update()
    {
        Vector3 blinkerPosition = blinker.transform.localPosition;
        blinkerPosition.y = -(baseLineOffset + ((float)text.textInfo.lineCount - 1) * lineHeight);
        blinker.transform.localPosition = blinkerPosition;

        switch(m_state)
        {
            case LineDisplayState.Hidden:
            {
                
            }
            break;

            case LineDisplayState.Entering:
            {
                m_timer += Time.deltaTime;
                float t = Ease.QuadOut(Mathf.Clamp01(m_timer / enterAnimationLength));

                Color sourceColor = text.color;
                sourceColor.a = 0.0f;
                Color targetColor = text.color;
                targetColor.a = 1.0f;
                Color c = Color.Lerp(sourceColor, targetColor, t);
                text.color = c;

                Vector3 sourcePosition = text.rectTransform.localPosition;
                sourcePosition.y = -enterTravelLength;
                Vector3 targetPosition = text.rectTransform.localPosition;
                targetPosition.y = 0.0f;
                Vector3 p = Vector3.Lerp(sourcePosition, targetPosition, t);
                text.rectTransform.localPosition = p;

                if (t >= 1.0f)
                {
                    setState(LineDisplayState.Displayed);
                }
            }
            break;

            case LineDisplayState.Displayed:
            {
            }
            break;

            case LineDisplayState.Exiting:
            {
                m_timer += Time.deltaTime;
                float t = Ease.QuadOut(Mathf.Clamp01(m_timer / exitAnimationLength));

                Color sourceColor = text.color;
                sourceColor.a = 1.0f;
                Color targetColor = text.color;
                targetColor.a = 0.0f;
                Color c = Color.Lerp(sourceColor, targetColor, t);
                text.color = c;

                Vector3 sourcePosition = text.rectTransform.localPosition;
                sourcePosition.y = 0.0f;
                Vector3 targetPosition = text.rectTransform.localPosition;
                targetPosition.y = exitTravelLength;
                Vector3 p = Vector3.Lerp(sourcePosition, targetPosition, t);
                text.rectTransform.localPosition = p;

                if (t >= 1.0f)
                {
                    setState(LineDisplayState.Hidden);
                }
            }
            break;
        }

    }

    public void setText(string _text)
    {
        text.SetText(_text);
        text.ForceMeshUpdate();

        /*float unityLineHeight = text.font.faceInfo.lineHeight * unityLineHeightRatio;
        Vector3 blinkerPosition = blinker.transform.position;
        blinkerPosition.y = ((float)text.textInfo.lineCount - 0.5f) * unityLineHeight;
        blinker.transform.position = blinkerPosition;*/
    }

    public LineDisplayState getState()
    {
        return m_state;
    }

    public void show()
    {
        setState(LineDisplayState.Entering);
    }

    public void hide()
    {
        setState(LineDisplayState.Exiting);
    }

    void setState(LineDisplayState _state)
    {
        if (_state == m_state)
            return;

        switch(m_state)
        {
            case LineDisplayState.Hidden:
            {
                
            }
            break;

            case LineDisplayState.Entering:
            {

            }
            break;

            case LineDisplayState.Displayed:
            {
                blinker.gameObject.SetActive(false);
            }
            break;

            case LineDisplayState.Exiting:
            {

            }
            break;
        }

        Debug.Log(string.Format("Line state: {0} -> {1}", m_state, _state));
        m_state = _state;

        switch(m_state)
        {
            case LineDisplayState.Hidden:
            {
                Color c = text.color;
                c.a = 0.0f;
                text.color = c;
            }
            break;

            case LineDisplayState.Entering:
            {
                Color c = text.color;
                c.a = 0.0f;
                text.color = c;

                Vector3 p = text.rectTransform.localPosition;
                p.y = -enterTravelLength;
                text.rectTransform.localPosition = p;

                m_timer = 0.0f;
            }
            break;

            case LineDisplayState.Displayed:
            {
                blinker.gameObject.SetActive(true);

                Color c = text.color;
                c.a = 1.0f;
                text.color = c;

                Vector3 p = text.rectTransform.localPosition;
                p.y = 0.0f;
                text.rectTransform.localPosition = p;
            }
            break;

            case LineDisplayState.Exiting:
            {
                Color c = text.color;
                c.a = 1.0f;
                text.color = c;

                Vector3 p = text.rectTransform.localPosition;
                p.y = 0.0f;
                text.rectTransform.localPosition = p;

                m_timer = 0.0f;
            }
            break;
        }
    }

    LineDisplayState m_state = LineDisplayState.Hidden;
    float m_timer = 0.0f;
}
