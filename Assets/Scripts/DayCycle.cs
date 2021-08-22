using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DayCycleImage
{
    public Texture2D image;
    public float time;
}

public class DayCycle : MonoBehaviour
{
    public List<DayCycleImage> images;

    [HideInInspector]
    public float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
