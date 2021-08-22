using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public float speed = 1.0f;
    public List<ParallaxLayer> layers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_distanceTravelled += -speed * Time.deltaTime;
        foreach (ParallaxLayer layer in layers)        
        {
            layer.position = m_distanceTravelled;
        }
    }

    float m_distanceTravelled = 0.0f;
}
