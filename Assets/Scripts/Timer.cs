using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float seconds = 1;
    public int minutes = 0;
    public int hours = 0;
    
    public TMP_Text TimerText;

    private void Start()
    {
        TimerText.text = hours + ":" + "0" + ":" + "0";
    }


    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60)
        {
            minutes++;
            seconds = 0;
   
            if (minutes >= 60)
            {
                hours++;
                minutes = 0;
            }
        }
        if (hours >= 1)
        {
            TimerText.text = string.Format("{0:0}", hours) + ":" + string.Format("{0:00}", minutes) + ":" + string.Format("{0:00.00}", seconds);
        }
        else
        {
            TimerText.text = string.Format("{0:00}", minutes) + ":" + string.Format("{0:00.00}", seconds);
        }
        
    }
}
