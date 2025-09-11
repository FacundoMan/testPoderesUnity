using System;
using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Boolean IsPilonActive;
    void Start()
    {
        IsPilonActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(instanciarPilonTest());
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
