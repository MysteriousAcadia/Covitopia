using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    AgentController agent;

    public Waypoint currentWaypoint;

    int direction;

    private void Awake()
    {
        agent = GetComponent<AgentController>();
        direction = Random.Range(0, 2);
        agent.speed = Random.Range(3f, 4f);
    }

    private void Start()
    {
        agent.SetDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if (agent.reachedDestination)
        {
            bool shouldBranch = false;

            if(currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRatio ? true : false;
            }
            if (shouldBranch)
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
            }
            else
            {
                if (direction == 0)
                {
                    if(currentWaypoint.nextWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                        direction = 1;
                    }
                }
                else
                {
                    if (currentWaypoint.previousWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                        direction = 0;
                    }
                }
            }
            
            agent.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
