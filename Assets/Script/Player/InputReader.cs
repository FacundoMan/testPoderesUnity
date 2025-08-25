using UnityEngine;
using UnityEngine.InputSystem;


public class InputReader : MonoBehaviour
{
   public static InputReader Instance { get; private set; }

    // Evento C# puro
    public event System.Action<Vector2> OnMove;
    public event System.Action OnJump;
    private PlayerInput playerInput;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); return; }

        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Vector2 value = playerInput.actions["Movement"].ReadValue<Vector2>();
        OnMove?.Invoke(value);   // lanzamos el evento

         // Detectar el botón de salto
    if (playerInput.actions["Jump"].WasPressedThisFrame())
        OnJump?.Invoke();
    }
}
