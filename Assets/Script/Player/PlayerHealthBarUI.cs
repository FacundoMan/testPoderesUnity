using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField]private PlayerScript playerScript;

   [SerializeField] private Slider healthBoss;

    void Start()
    {
        healthBoss = GetComponent<Slider>();
    }

    public void SetValue(int current)
    {
        Debug.Log("player"+ current);
        healthBoss.value = current;
    }
    public void SetMaxValue(int current)
    {
        
        healthBoss.maxValue = current;
    }

    private void OnEnable()     // o Start/Awake
    {
        playerScript.OnHealthChangedPlayer += SetValue;
        playerScript.OnMaxHealthSetPlayer += SetMaxValue;
    }

    private void OnDisable() // <-- DESUSCRIPCIÓN
    {
        playerScript.OnHealthChangedPlayer -= SetValue;  
        playerScript.OnMaxHealthSetPlayer -= SetMaxValue;
    }

}
