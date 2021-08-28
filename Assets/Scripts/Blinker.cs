using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using grouflon;

public class Blinker : MonoBehaviour
{
    public float blinkPeriod = 2.0f;
    public float blinkHighValue = 1.0f;
    public float blinkLowValue = 0.0f;
    public float fullDisplayTime = 1.0f;

    public void setColor(Color _color)
    {
        Material m = m_renderer.material;
        m.color = _color;
    }

    public void resetTime()
    {
        m_time = 0.0f;
    }

    void Awake()
    {
        m_renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Material m = m_renderer.material;
        Color c = m.color;
        float t = ((Mathf.Sin((m_time / blinkPeriod) * Mathf.PI * 2.0f) + 1.0f) * 0.5f);
        t *= Ease.QuadOut(Mathf.Clamp01(m_time / fullDisplayTime));
        c.a =  blinkLowValue + (blinkHighValue - blinkLowValue) * t;
        m.color = c;

        m_time += Time.deltaTime;
    }


    float m_time = 0.0f;
    MeshRenderer m_renderer;
}
