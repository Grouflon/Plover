using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeController : MonoBehaviour
{
    public Transform dayBackdrop;
    public Transform nightBackdrop;
    public SpriteRenderer plover;
    public Color ploverNightColor;

    public void setDayTime(string _dayTimeName)
    {
        switch(_dayTimeName)
        {
            case "day":
            {
                dayBackdrop.gameObject.SetActive(true);
                nightBackdrop.gameObject.SetActive(false);
                plover.color = Color.white;
            }
            break;

            case "night":
            {
                dayBackdrop.gameObject.SetActive(false);
                nightBackdrop.gameObject.SetActive(true);
                plover.color = ploverNightColor;
            }
            break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
