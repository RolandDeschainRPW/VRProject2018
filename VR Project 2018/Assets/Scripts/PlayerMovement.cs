using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public Camera cam;

    [SerializeField] float m_JumpPower = 12f;
    [SerializeField] float m_GroundCheckDistance = 0.1f;

    Animator anim;
    Vector3 movement;
    Rigidbody playerRigidbody;
    Vector3 m_GroundNormal;
    Animator m_Animator;

    bool m_IsGrounded =true;
    private bool m_Jump;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
    }

   private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float v = CrossPlatformInputManager.GetAxisRaw("Vertical");
        m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");

        Move(h, v, m_Jump);
        Animating(h, v);
    }

    private void Move(float h, float v, bool jump)
    {
        CheckGroundStatus();

        // control and velocity handling is different when grounded and airborne:
        if (m_IsGrounded)
        {
            HandleGroundedMovement(jump, h, v);
        }
        else
        {
            HandleAirborneMovement(h, v);
        }

    }

    void HandleAirborneMovement(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void HandleGroundedMovement(bool jump, float h, float v)
    {
        // check whether conditions are right to allow a jump:
        if (jump && m_IsGrounded)
        {
            // jump!
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, m_JumpPower, playerRigidbody.velocity.z);
            m_IsGrounded = false;
            m_Animator.applyRootMotion = false;
            m_GroundCheckDistance = 0.1f;
        }
        else
        {
            movement.Set(h, 0f, v);
            movement = movement.normalized * Time.deltaTime;
            playerRigidbody.MovePosition(transform.position + movement);
        }
    }

        private void Animating(float h, float v)
    {
        bool run = h == 0f && v > 0.1f;
        bool runBack = h == 0f && v < -0.1f;
        bool runLeft = h < -0.1f && v == 0f;
        bool runRight = h > 0.1f && v == 0f;
        anim.SetBool("runningForwards", run);
        anim.SetBool("runningBackwards", runBack);
        anim.SetBool("runningRight", runRight);
        anim.SetBool("runningLeft", runLeft);
    }

    void CheckGroundStatus()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(transform.position + (Vector3.up * 0.05f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
#endif
        // 0.1f is a small offset to start the ray from inside the character
        // it is also good to note that the transform position in the sample assets is at the base of the character
        if (Physics.Raycast(transform.position + (Vector3.up * 0.05f), Vector3.down, out hitInfo, m_GroundCheckDistance))
        {
            m_GroundNormal = hitInfo.normal;
            m_IsGrounded = true;
            m_Animator.applyRootMotion = true;
            Debug.Log("hit !!!!");
        }
        else
        {
            m_IsGrounded = false;
            m_GroundNormal = Vector3.up;
            m_Animator.applyRootMotion = false;
            Debug.Log("no hit");
        }
    }

}
