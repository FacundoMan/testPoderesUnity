using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputReader : MonoBehaviour
{
   public static InputReader Instance { get; private set; }

    // Evento C# puro
    public event Action<Vector2> OnMove;
    public event Action OnJump;
     public event Action<string> OnAbilityPressed;
    private PlayerInput playerInput;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); return; }

        playerInput = GetComponent<PlayerInput>();
         // Habilidades 1-4 y Q-E
        if (WasPressed("Ability1")) OnAbilityPressed?.Invoke("Ability1");
        if (WasPressed("Ability2")) OnAbilityPressed?.Invoke("Ability2");
        if (WasPressed("Ability3")) OnAbilityPressed?.Invoke("Ability3");
        if (WasPressed("Ability4")) OnAbilityPressed?.Invoke("Ability4");
        if (WasPressed("Ability5")) OnAbilityPressed?.Invoke("Ability5");
        if (WasPressed("Ability6")) OnAbilityPressed?.Invoke("Ability6");
    }

    private bool WasPressed(string actionName) =>
        playerInput.actions[actionName].WasPressedThisFrame();
    private void Update()
    {
        Vector2 value = playerInput.actions["Movement"].ReadValue<Vector2>();
        OnMove?.Invoke(value);   // lanzamos el evento

        // Detectar el botón de salto
        if (playerInput.actions["Jump"].WasPressedThisFrame())
            OnJump?.Invoke();
    }
}
