using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    PlayerHealth PlayerHealth;
    

    public int HPbonus = 10;

    private void Awake()
    {
        PlayerHealth = FindObjectOfType<PlayerHealth>();
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(PlayerHealth.currentHealth<PlayerHealth.startingHealth)
        {

            Destroy(gameObject);
            PlayerHealth.Restore(HPbonus);
          
            
        }
    }
}
