using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxLayer : MonoBehaviour
{
    public float speed = 1.0f;
    public float position = 0.0f;

    void Awake()
    {
        m_propertyBlock = new MaterialPropertyBlock();
        m_renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        m_renderer.GetPropertyBlock(m_propertyBlock);
        m_propertyBlock.SetVector("_MainTex_ST", new Vector4(1.0f, 1.0f, position * speed, 0.0f));
        m_renderer.SetPropertyBlock(m_propertyBlock);
    }

    Renderer m_renderer;
    MaterialPropertyBlock m_propertyBlock;
}
