using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class WinManager : MonoBehaviour
    {
        public EnemyHealth virusHealth;       // Reference to the main virus health.
        public float restartDelay = 10f;
        

        Animator anim;                          // Reference to the animator component.
        float restartTimer;


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

                restartTimer += Time.deltaTime;
                if (restartTimer >= restartDelay)
                {
                    Scene loadedLevel = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(loadedLevel.buildIndex);
                    GameObject.FindGameObjectWithTag("GM").GetComponent<MyGameManagerScript>().setGameOverState();
                    GameObject.FindGameObjectWithTag("GM").GetComponent<MyGameManagerScript>().Unlock();
                }
            }
        }
    }
}