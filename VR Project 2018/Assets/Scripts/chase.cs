using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour
{

    private Transform player;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        //float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.position, this.transform.position) < 100000 /*&& angle < 30*/)
        {

            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 1)
            {
                this.transform.Translate(0, 0, 0.03f);
                anim.SetBool("isMoving", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isMoving", false);
            }

        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isMoving", false);
            anim.SetBool("isAttacking", false);
        }

    }
}