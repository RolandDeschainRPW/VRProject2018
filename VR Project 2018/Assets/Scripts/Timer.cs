using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool finished = true;
    private string levelName;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (finished) return;
        
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timerText.text = levelName + minutes + ":" + seconds;

        // If we reach 2 minutes, the timer stops
        if ((int)t / 60 == 2)
        {
            finished = true;
            GameObject.FindGameObjectWithTag("GM").GetComponent<MyGameManagerScript>().Unlock();
        }
    }

    public void finish()
    {
        finished = true;
        timerText.text = "";
    }

    public void beginTimer(string levelName)
    {
        startTime = Time.time;
        this.levelName = levelName + "\n";
        finished = false;
    }
}
