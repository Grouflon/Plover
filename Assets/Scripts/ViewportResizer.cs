using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewportResizer : MonoBehaviour
{
    public Vector2 viewportMaxSize = new Vector2(1380.0f, 390.0f);

    void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float ratio = viewportMaxSize.y / viewportMaxSize.x;
        float width = Mathf.Min(Screen.width, viewportMaxSize.x);
        Vector2 size = new Vector2(width, width * ratio);
        m_rectTransform.sizeDelta = size;
        Vector3 position = new Vector3(Mathf.Floor((Screen.width - size.x) * 0.5f), Mathf.Floor((Screen.height - size.y) * 0.5f), 0.0f);
        m_rectTransform.anchoredPosition = position;
    }
    
    RectTransform m_rectTransform;
}
