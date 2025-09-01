using System;
using System.Collections;
using UnityEngine;

public class Pilon : MonoBehaviour
{

    [SerializeField] private int velMax;
    [SerializeField] private int velMin;
    [SerializeField] private Rigidbody pilarRb;

    [SerializeField] private int velFin;
    private void Start()
    {
        
    }

    private void Onable()
    {
        velFin = UnityEngine.Random.Range(velMin, velMax + 1);
        pilarRb.linearVelocity = Vector3.up * velFin;
        StartCoroutine(destruir());
    }

    IEnumerator destruir()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
