using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI timerText;
   [SerializeField] TextMeshProUGUI timerTextGameOver;
   float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime%60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
        timerTextGameOver.text = timerText.text;
    }

}
