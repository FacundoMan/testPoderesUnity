using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{


    public float upForce = 5f, force = 5f;
    private Rigidbody rb;
    private PlayerInput playerInput;
    private Vector2 input;
     private bool canJump = true;

       private void OnEnable()
       
    {
        InputReader.Instance.OnJump += HandleJump;
        InputReader.Instance.OnMove += HandleMove;
    }

    private void OnDisable()
    {
        InputReader.Instance.OnMove -= HandleMove;
        InputReader.Instance.OnJump -= HandleJump;
    }

    private void HandleMove(Vector2 vector)
    {
         Vector3 vel = new Vector3(input.x, 0f, input.y) * force;
         rb.linearVelocity = new Vector3(vel.x,rb.linearVelocity.y,vel.z);
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        
    }
    void Update()
    {
        input = playerInput.actions["Movement"].ReadValue<Vector2>();

    }
    void FixedUpdate()
    {
    }

    
    public void HandleJump()
    {
        if (canJump)
        {

            rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
            StartCoroutine(JumpCooldown()); //Cooldown jump
        }
    }
    
    private IEnumerator JumpCooldown()
    {
        canJump = false;
        yield return new WaitForSeconds(1f);
        canJump = true;
    }
}
