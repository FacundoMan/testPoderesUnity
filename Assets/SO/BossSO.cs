using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss", menuName = "Boss Data")]
public class BossSO : ScriptableObject
{
    [SerializeField] private string nameBoss;
    [SerializeField] private EnumElementry element;
    [SerializeField] private int damage;
    [SerializeField] private List<ScriptableObject> loot;
    [SerializeField] private List<ScriptableObject> ability;
    [SerializeField] private int maxHealth;
    //Cantidad de armadura del boss
    [SerializeField] private int armor;

    [SerializeField] private string description;

    public string NameBoss { get { return nameBoss; } }
    public EnumElementry Element { get { return element; } }
    public int Damage { get { return damage; } }
    public List<ScriptableObject> Loot { get { return loot; } }
    public List<ScriptableObject> Ability { get { return ability; } }
    public int MaxHealth { get { return maxHealth; } }
    public string Description{get{ return description; }}
    

    
}
