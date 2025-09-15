using System;
using UnityEngine;
using UnityEngine.UI;

public class StatusBossBarsUI : MonoBehaviour
{
    [SerializeField]private BossController bossController;

   [SerializeField] private Slider healthBoss;

    void Start()
    {
        healthBoss = GetComponent<Slider>();
    }

    public void SetValue(int current)
    {
        Debug.Log(current);
        healthBoss.value = current;
    }
    public void SetMaxValue(int current)
    {
        
        healthBoss.maxValue = current;
    }

    private void OnEnable()     // o Start/Awake
    {
        bossController.OnHealthChanged += SetValue;
        bossController.OnMaxHealthSet += SetMaxValue;
    }

    private void OnDisable() // <-- DESUSCRIPCIÓN
    {
        bossController.OnHealthChanged -= SetValue;  
        bossController.OnMaxHealthSet += SetMaxValue;
    }


}
