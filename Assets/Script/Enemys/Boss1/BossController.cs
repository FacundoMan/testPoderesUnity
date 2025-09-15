using System;
using System.Collections;
using UnityEditor.AssetImporters;
using UnityEngine;

public class BossController : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Boolean IsPilonActive;

    [SerializeField] private BossSO bossSO;

    private int currentHealth;
    private int maxHealth;

    //Events
    public event Action<int> OnMaxHealthSet;
    public event System.Action<int> OnHealthChanged;
    void Awake()
    {
        currentHealth = bossSO.MaxHealth;
        maxHealth = bossSO.MaxHealth;
    }
    void Start()
    {
        IsPilonActive = false;
        OnMaxHealthSet?.Invoke(maxHealth);
        OnHealthChanged?.Invoke(currentHealth);
        StartCoroutine(testDamage());
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(instanciarPilonTest());
        
    }

    IEnumerator testDamage()
    {
        yield return new WaitForSeconds(3f);
        TakeDamage(10);
    }
      public void TakeDamage(int amount)
    {
        currentHealth = Math.Clamp(currentHealth - amount, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth);
    }
    [ContextMenu("Test TakeDamage")]
      public void TakeDamageTest()
    {
        currentHealth = Math.Clamp(currentHealth - 10, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth);
    }

    IEnumerator instanciarPilonTest()
    {
        
        if (!IsPilonActive)
        {   IsPilonActive = true;
            yield return new WaitForSeconds(3f);
            GameObject pilon = PilonPool.Instance.RequestPilon();
            pilon.transform.position = player.transform.position;
            IsPilonActive = false;
        }
        
    }
}
