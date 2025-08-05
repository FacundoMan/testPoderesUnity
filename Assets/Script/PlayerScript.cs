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

    void Start()
    {
        Debug.Log("Script activo");
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        input = playerInput.actions["Movement"].ReadValue<Vector2>();

    }
    void FixedUpdate()
    {
        rb.AddForce(new Vector3(input.x, 0f, input.y) * force);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && canJump)
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
