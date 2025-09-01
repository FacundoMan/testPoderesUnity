using System.Collections.Generic;
using UnityEngine;

public class PilonPool : MonoBehaviour
{
    [SerializeField] private GameObject pilonPref;
    [SerializeField] private int poolSize;
    [SerializeField] private List<GameObject> pilonList;

    private static PilonPool instance;
    public static PilonPool Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject pilon = Instantiate(pilonPref);
            pilon.SetActive(false);
            pilonList.Add(pilon);
            pilon.transform.parent = transform;
        }
    }

    public GameObject RequestPilon()
    {
        for (int i = 0; i < pilonList.Count; i++)
        {
            if (!pilonList[i].activeSelf)
            {
                pilonList[i].SetActive(true);
                return pilonList[i];
            }
        }
        return null;
    }
   
}
