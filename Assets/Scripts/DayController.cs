using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour
{
    public float timeOfDay = 0.0f;
    public List<DayCycle> cycles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (DayCycle cycle in cycles)
        {
            cycle.time = timeOfDay;
        }
    }
}
