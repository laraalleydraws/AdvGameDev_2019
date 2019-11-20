using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] float decisionDelay = 3f;
    [SerializeField] public GameObject objectToChase;
    [SerializeField] Transform[] waypoints;
    public int currentWaypoint = 0;
    public float threshold = 3f;
    public GameObject player;

    RaycastHit hit;
    Vector3 rayDirection;

    enum ENEMY_STATES { Patrolling, Chasing };
    ENEMY_STATES state;

    void Start()
    {
        state = ENEMY_STATES.Patrolling;
        agent = gameObject.GetComponent<NavMeshAgent>();
        //InvokeRepeating("SetDestination", 1.5f, decisionDelay);
    }

   

    void Update()
    {
        rayDirection = (player.transform.position - transform.position);
        bool raycastdown = Physics.Raycast(transform.position, rayDirection, out hit);

        if (raycastdown && hit.transform.name.Equals("Agent"))
        {
            state = ENEMY_STATES.Chasing;
        }
        else
        {
            state = ENEMY_STATES.Patrolling;
        }

        switch (state)
        {
            case ENEMY_STATES.Chasing:
                agent.SetDestination(player.transform.position);
                break;

            case ENEMY_STATES.Patrolling:
                agent.SetDestination(waypoints[currentWaypoint].transform.position);
                break;
        }
        Debug.Log(state);           

    }

    public void RandomWaypoint()
    {
        int temp = Random.Range(0, waypoints.Length - 1);
        if (temp != currentWaypoint)
        {
            currentWaypoint = temp;
        }
        else
        {
            RandomWaypoint();
        }
        Debug.Log("temp = " + temp);
        Debug.Log("waypoint = " + currentWaypoint);
    }
}
