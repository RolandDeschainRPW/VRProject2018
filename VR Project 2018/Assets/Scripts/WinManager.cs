using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class WinManager : MonoBehaviour
    {
        public EnemyHealth virusHealth;       // Reference to the main virus health.
        
        Animator anim;                          // Reference to the animator component.
        
        void Awake ()
        {
            // Set up the reference.
            anim = GameObject.FindGameObjectWithTag("HUD").GetComponent<Animator>();
        }


        void Update ()
        {
            // If the main virus has run out of health...
            if(virusHealth.currentHealth <= 0)
            {
                // ... tell the animator the player won the game.
                anim.SetTrigger ("Win");

                if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                {
                    // Back to Main Menu
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}