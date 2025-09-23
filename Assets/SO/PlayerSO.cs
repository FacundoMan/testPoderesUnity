using UnityEngine;
[CreateAssetMenu(fileName = "PlayerSO", menuName = "Player Data")]
public class PlayerSO : ScriptableObject
{
[Header("Identity")]
    [SerializeField] private string characterName;
    public string CharacterName => characterName;

    [Header("Combat")]
    [SerializeField] private int maxHealth;
    public int MaxHealth => maxHealth;

    [SerializeField] private int baseDamage;
    public int BaseDamage => baseDamage;

    [SerializeField] private float attackSpeed;
    public float AttackSpeed => attackSpeed;

    [SerializeField] private float critChance;
    public float CritChance => critChance;

    [SerializeField] private float critMultiplier;
    public float CritMultiplier => critMultiplier;

    [Header("Defense")]
    [SerializeField] private int baseArmor;
    public int BaseArmor => baseArmor;
   
    [SerializeField] private float dodgeChance
    ;
    public float DodgeChance => dodgeChance;
    
    [SerializeField] private int resitenceWater;
    public int ResitenceWater => resitenceWater;
    [SerializeField] private int resitenceFire;
    public int ResitenceFire => resitenceFire;
    [SerializeField] private int resitenceAir;
    public int ResitenceAir => resitenceAir;
    [SerializeField] private int resitenceEarth;
    public int ResitenceEarth => resitenceEarth;
    [SerializeField] private int resitenceVoid;
    public int ResitenceVoid => resitenceVoid;
    [SerializeField] private int resitenceLight;
    public int ResitenceLight => resitenceLight;
    [SerializeField] private int resitenceDarkness;
    public int ResitenceDarkness => resitenceDarkness;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    public float MoveSpeed => moveSpeed;

    [Header("Resources")]
    [SerializeField] private int maxMana;
    public int MaxMana => maxMana;


    
}
