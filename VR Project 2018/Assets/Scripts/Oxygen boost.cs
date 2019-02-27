using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygenboost : MonoBehaviour
{
    // Start is called before the first frame update
    Oxygen_decr Oxy;
    public int Oxygen_bonus = 10;

    private void Awake()
    {
        Oxy = FindObjectOfType<Oxygen_decr>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(Oxy.Ox<Oxy.MAXOX)
        {
            Destroy(gameObject);
            Oxy.Ox = Oxy.Ox + Oxygen_bonus;
            

        }

    }

}
