using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    public EnumAbilityState abilityState=EnumAbilityState.READY;
    float cooldownTime;
    float activeTime;
    void Update()
    {
        switch (abilityState)
        {
            case EnumAbilityState.READY:
                if (Keyboard.current.qKey.wasPressedThisFrame)
                {
                    Debug.Log("Entro");
                    ability.Activate(gameObject);
                    abilityState = EnumAbilityState.ACTIVE;
                    activeTime = ability.activeTime;

                }
                break;
            case EnumAbilityState.ACTIVE:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                    Debug.Log("active "+activeTime);
                }
                else
                {
                    abilityState = EnumAbilityState.COOLDOWN;
                    cooldownTime = ability.cooldownTime;
                }
                break;
            case EnumAbilityState.COOLDOWN:
                if (cooldownTime > 0)
                {
                    Debug.Log("cooldown" +cooldownTime);
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    abilityState = EnumAbilityState.READY;
                }  
                break;
        }
    }

    
}
