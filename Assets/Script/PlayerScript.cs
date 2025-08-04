using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    // Update is called once per frame
   
    public float upForce = 5f;
    private Rigidbody rb;

    void Start()
    {
        Debug.Log("Script activo");
        rb = GetComponent<Rigidbody>();
        GetComponent<PlayerInput>().ActivateInput(); // Forzar activación del input map
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump!");
            rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        }
    }
}
