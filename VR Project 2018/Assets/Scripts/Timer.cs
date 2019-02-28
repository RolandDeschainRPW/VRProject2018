using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool finished = true;
    private bool spawnersDeactivated = true;
    private bool startTimeSet = false;
    private string levelName;
    private float beginCounter = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (finished) return;
        if (beginCounter > 0)
        {
            beginCounter -= Time.deltaTime;
            timerText.text = "Defeat the waves of infections!\n" + Mathf.Round(beginCounter);
            return;
        }

        setStartTime();

        activateSpawners();
        
        float t = Time.time - startTime;

        // if 100 seconds are passed, is time to deactivate the spawners!
        if (t >= 100 && !spawnersDeactivated)
        {
            deactivateSpawners();
        }

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timerText.text = levelName + "\n" + minutes + ":" + seconds;


        // If we reach 2 minutes, the timer stops
        if ((int)t / 60 == 2)
        //if ((int)t == 10)    //TEST MODE
        {
            string text = levelName.Equals("Heart", System.StringComparison.OrdinalIgnoreCase) ? "Kill the main virus!" : "Go to the next level!";
            finish(text);
            GameObject.FindGameObjectWithTag("GM").GetComponent<MyGameManagerScript>().Unlock();
        }
    }

    public void finish(string text)
    {
        finished = true;
        startTimeSet = false;
        deactivateSpawners();
        beginCounter = 3.0f;
        timerText.text = text;
    }

    public void beginTimer(string levelName)
    {
        this.levelName = levelName;
        finished = false;
    }

    private void setStartTime()
    {
        if (!startTimeSet)
        {
            startTime = Time.time;
            startTimeSet = true;
        }
    }

    private string findSpawnersSet()
    {
        string set = null;
        if (levelName.Equals("Stomach", System.StringComparison.OrdinalIgnoreCase)) {
            set = "StomachSpawnersSet";
        } else if (levelName.Equals("Liver", System.StringComparison.OrdinalIgnoreCase)) {
            set = "LiverSpawnersSet";
        } else if (levelName.Equals("Heart", System.StringComparison.OrdinalIgnoreCase)) {
            set = "HeartSpawnersSet";
        }
        return set;
    }

    private void activateSpawners()
    {
        string set = findSpawnersSet();
        GameObject.FindGameObjectWithTag(set).GetComponent<SpawnersSet>().activateSpawners();
        spawnersDeactivated = false;
    }

    private void deactivateSpawners()
    {
        string set = findSpawnersSet();
        GameObject.FindGameObjectWithTag(set).GetComponent<SpawnersSet>().deactivateSpawners();
        spawnersDeactivated = true;
    }
}
