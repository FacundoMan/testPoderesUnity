using UnityEngine;

public class FollowIA : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    [SerializeField] private float minDistance;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }
    void FixedUpdate()
    {
        
    }

    private void Follow()
    {
        //Checka si esta a una distancia minima del player
        if (Vector3.Distance(transform.position, player.position) > minDistance)
        {
            //Se mueve al lugar del player
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {

        }
        
    }

}
