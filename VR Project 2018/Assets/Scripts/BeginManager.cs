using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginManager : MonoBehaviour
{
    // Reference to the animator component.
    Animator anim;

    void Awake()
    {
        // Set up the reference.
        anim = GameObject.FindGameObjectWithTag("HUD").GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetTrigger("Begin");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Timer>().beginTimer("Stomach");
        }
    }
}
