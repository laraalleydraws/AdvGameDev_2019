using UnityEngine;
using UnityEngine.AI;
public class Agent : MonoBehaviour
{

    NavMeshAgent agent;

    void Start()
    {
        // get a reference to the player's Nav Mesh Agent component
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
