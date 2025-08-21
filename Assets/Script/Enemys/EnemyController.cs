using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour

{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    [SerializeField] private float minDistanceAtack;

    [SerializeField] private float maxDistanceAggro;

    //Distancia maxima del punto de ataque
    [SerializeField] private float maxDistanceStartPointAttack;

    [SerializeField] private Transform[] waypoints;

    [SerializeField] private float waitTime;

    [SerializeField] private float cooldownFollow;

    [SerializeField] private float radiusSearch;


    public float maxHealth = 100;
    [SerializeField] private float currentHealth;

    private HealthBarEnemy healthBar;


    //es el punto donde el enemigo detecta al player
    private Vector3 startPointAttack;
    private int currentWaypoint;
    private bool isWaiting;

    //Boleano que checka si esta dentro del rango
    private bool isInsideRange;

    [SerializeField] private MovementStates currentSate;
    private enum MovementStates
    {
        Waiting,
        Following,
        Returning,
    }

    
    void Start()
    {
        currentHealth = maxHealth;

        // instancia prefab de barra y lo inicializa
        Canvas canvas = GameObject.Find("EnemyUIManager").GetComponent<Canvas>();
        GameObject barObj = Instantiate(Resources.Load("HealthBarEnemy")) as GameObject;
        barObj.transform.SetParent(canvas.transform, false);   // importante: false = conservar escala/pos
        healthBar = barObj.GetComponent<HealthBarEnemy>();
        healthBar.Setup(transform);
        healthBar.SetHealth(currentHealth / maxHealth);
        StartCoroutine(TestDamage());
    }

    IEnumerator TestDamage()
    {

        yield return new WaitForSeconds(1);
        TakeDamage(30);
        Debug.Log("Tomo daño");
    }
   

    // Update is called once per frame
    void Update()
    {
        

        switch (currentSate)
        {
            case MovementStates.Following:
                Follow();
                break;
            case MovementStates.Waiting:
                Patrol();
                break;
            case MovementStates.Returning:
                Return();
                break;
        }



    }

    private void Patrol()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radiusSearch);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                player = collider.transform;
                startPointAttack = transform.position;
                isInsideRange = true;
                currentSate = MovementStates.Following;
            }
        }

        if (transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        else if (!isWaiting)
        {
            StartCoroutine(Wait());

        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;

        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }
        isWaiting = false;
    }

    private void Follow()
    {
        if (player == null)
        {
            currentSate = MovementStates.Returning;
            return;
        }
        //Checka si esta a una distancia minima del player
        if (Vector3.Distance(transform.position, player.position) > minDistanceAtack && player != null && isInsideRange)
        {

            //Se mueve al lugar del player
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        //Verifica la distancia entre el jugador y el enemigo o el punto inicial del ataque y el enemigo, si se salen de rango de cualquiera de los 2 vuelve a patruyar 
        if (Vector3.Distance(transform.position, player.position) > maxDistanceAggro || Vector3.Distance(transform.position, startPointAttack) > maxDistanceStartPointAttack)
        {
            currentSate = MovementStates.Returning;
            isInsideRange = false;
            player = null;
        }

    }
    private void Return()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPointAttack, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, startPointAttack) < 0.10f)
        {

            StartCoroutine(cooldownFollowing());
        }
    }


    IEnumerator cooldownFollowing()
    {

        yield return new WaitForSeconds(cooldownFollow);
        currentSate = MovementStates.Waiting;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radiusSearch);
    }
    
     public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);

        healthBar.SetHealth(currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
