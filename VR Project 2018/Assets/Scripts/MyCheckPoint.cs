using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCheckPoint : MonoBehaviour
{
    private MyGameManagerScript gm;
    public int checkPointNum;

    private void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Player")) {
            gm.lastCheckPointPos = transform.position;
            gm.checkPointNum = checkPointNum;
            Debug.Log(gm.GetInstanceID());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<MyGameManagerScript>();
    }
}
