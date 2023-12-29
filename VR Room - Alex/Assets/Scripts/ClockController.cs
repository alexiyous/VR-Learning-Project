using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    [SerializeField] private GameObject hourHand;
    [SerializeField] private GameObject minuteHand;
    [SerializeField] private GameObject secondHand;
    private int oldSeconds;
    private int timeInSeconds;

    // Update is called once per frame
    void Update()
    {
        ConvertTimeInSeconds();
        RotateClock();
    }

    private void ConvertTimeInSeconds()
    {
        int currentSeconds = DateTime.Now.Second;
        int currentMinutes = DateTime.Now.Minute;
        int currentHours = DateTime.Now.Hour;

        if (currentHours >= 12)
        {
            currentHours -= 12;
        }

        timeInSeconds = (currentHours * 3600) + (currentMinutes * 60) + currentSeconds;
    }

    private void RotateClock()
    {
        float secondsRotation = 360f / 60f;
        float minutesRotation = 360f / 3600f;
        float hoursRotation = 360f / (60f * 60f * 12f);

        if (timeInSeconds != oldSeconds)
        {
            secondHand.transform.localRotation = Quaternion.Euler(0f, timeInSeconds * secondsRotation, 0f);
            minuteHand.transform.localRotation = Quaternion.Euler(0f, timeInSeconds * minutesRotation, 0f);
            hourHand.transform.localRotation = Quaternion.Euler(0f, timeInSeconds * hoursRotation, 0f);
        }
        oldSeconds = timeInSeconds;
    }
}
