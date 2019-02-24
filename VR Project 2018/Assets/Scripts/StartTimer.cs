using UnityEngine;
using System.Collections;

public class StartTimer : MonoBehaviour {

    public GameObject block;
    public string levelName;
    private bool activated = false;

    private void OnTriggerEnter(Collider col) {
        if (activated) return;
        if (col.CompareTag("Player"))
        {
            block.gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Timer>().beginTimer(levelName);
            activated = true;
        }
    }
}