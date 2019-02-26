using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersSet : MonoBehaviour
{
    public GameObject[] spawners;

    public void deactivateSpawners()
    {
        foreach (GameObject go in spawners)
        {
            go.SetActive(false);
        }
    }

    public void activateSpawners()
    {
        foreach (GameObject go in spawners)
        {
            go.SetActive(true);
        }
    }
}
