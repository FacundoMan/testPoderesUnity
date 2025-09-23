using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerScript : MonoBehaviour
{

    [Header("Identity")]
    private string characterName;
    [Header("Combat")]
    private int maxHealth;
    private int baseDamage;
    private float attackSpeed;
    private float critChance;
    private float critMultiplier;
    [Header("Defense")]
    private int baseArmor;
    private float dodgeChance;
    private int resitenceWater;
    private int resitenceFire;
    private int resitenceAir;
    private int resitenceEarth;
    private int resitenceVoid;
    private int resitenceLight;
    private int resitenceDarkness;
    [Header("Movement")]
    private float moveSpeed;
    [Header("Resources")]
    private int maxMana;

    [SerializeField] private Transform camTransform; // arrastra MainCamera

    [Header("Jump")]
    [SerializeField] private float upForce = 5f;
    private Rigidbody rb;
    private bool canJump = true;
    private int currentHealth;
    [SerializeField] private PlayerSO playerSO;
    //Events
    public event Action<int> OnMaxHealthSetPlayer;
    public event System.Action<int> OnHealthChangedPlayer;
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
        Vector3 camRight = camTransform.right;
        camForward.y = 0f;
        camRight.y = 0f;
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
        cargarSO();

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
    public void TakeDamage(int amount)
    {
        currentHealth = Math.Clamp(currentHealth - amount, 0, maxHealth);
        OnHealthChangedPlayer?.Invoke(currentHealth);
    }
    [ContextMenu("Test TakeDamage")]
    public void TakeDamageTest()
    {
        currentHealth = Math.Clamp(currentHealth - 10, 0, maxHealth);
        OnHealthChangedPlayer?.Invoke(currentHealth);
    }

    public void cargarSO()
    {
        characterName = playerSO.CharacterName;
        maxHealth = playerSO.MaxHealth;
        baseDamage = playerSO.BaseDamage;
        attackSpeed = playerSO.AttackSpeed;
        critChance = playerSO.CritChance;
        critMultiplier = playerSO.CritChance;
        baseArmor = playerSO.BaseArmor;
        dodgeChance = playerSO.DodgeChance;
        resitenceWater = playerSO.ResitenceWater;
        resitenceFire = playerSO.ResitenceFire;
        resitenceAir = playerSO.ResitenceAir;
        resitenceEarth = playerSO.ResitenceEarth;
        resitenceVoid = playerSO.ResitenceVoid;
        resitenceLight = playerSO.ResitenceLight;
        resitenceDarkness = playerSO.ResitenceDarkness;
        moveSpeed = playerSO.MoveSpeed;
        maxMana = playerSO.MaxMana;
        currentHealth = playerSO.MaxHealth;
        OnMaxHealthSetPlayer?.Invoke(maxHealth);
        OnHealthChangedPlayer?.Invoke(currentHealth);
    }
}
