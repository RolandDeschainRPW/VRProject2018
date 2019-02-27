using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Oxygen_decr : MonoBehaviour
{
    public Slider ossigeno;
    public float Ox;
    public float MAXOX;// 1000
    void Start()
    {
        Ox = MAXOX;
        ossigeno = GetComponent<Slider>();
        ossigeno.maxValue = MAXOX;
        ossigeno.value = Ox;
    }
    void Update()
    {
        Ox -= 0.01f;
        ossigeno.value = Ox;
    }
   


}
