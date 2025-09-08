using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerScript : MonoBehaviour
{


    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;   // antes 'force'
    [SerializeField] private Transform camTransform; // arrastra MainCamera

    [Header("Jump")]
    [SerializeField] private float upForce = 5f;
    private Rigidbody rb;
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

    private void HandleMove(Vector2 input)
    {
        // direcciones planas de la cámara
        Vector3 camForward = camTransform.forward;
        Vector3 camRight   = camTransform.right;
        camForward.y = 0f;
        camRight.y   = 0f;
        camForward.Normalize();
        camRight.Normalize();

        // vector deseado en espacio mundo
        Vector3 desired = camForward * input.y + camRight * input.x;
        desired *= moveSpeed;

        // velocidad constante (sin aceleración)
        rb.linearVelocity = new Vector3(desired.x, rb.linearVelocity.y, desired.z);

        // rotación visual hacia donde camina
        if (desired != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(desired);
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (!camTransform) camTransform = Camera.main.transform;
    }

    void Start()
    {

    }
    void Update()
    {
        

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
