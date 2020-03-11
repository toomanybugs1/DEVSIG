using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public float timeToWin;
    public TextMeshProUGUI timerText;

    // Update is called once per frame
    void Update()
    {
        if (timeToWin <= 0)
            GameManager.WinLevel();

        //only needed this if to make sure it doesnt display less than 0
        if (timeToWin >= 0)
            timeToWin -= Time.deltaTime;

        timerText.text = "Time: " + timeToWin.ToString("F2");
    }
}
