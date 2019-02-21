using UnityEngine;
using System.Collections;

public class MyDoorTrigger : MonoBehaviour {

    public GameObject hidey;

    private void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Player")) hidey.gameObject.SetActive(false);
    }
}