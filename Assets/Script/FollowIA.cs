using UnityEngine;

public class FollowIA : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void FixedUpdate()
    {
          transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
