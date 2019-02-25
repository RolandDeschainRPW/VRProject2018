using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player")) {
            col.gameObject.GetComponent<PlayerHealth>().fallDeath();
        } else if (col.gameObject.CompareTag("Shootable")) {
            col.gameObject.GetComponent<EnemyHealth>().fallDeath();
        }
    }
}
