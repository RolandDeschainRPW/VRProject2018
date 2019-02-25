using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreEnemyCollisions : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shootable"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shootable"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
        }
    }
}
