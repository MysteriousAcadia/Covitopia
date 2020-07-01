using UnityEngine;

public class AgentController : MonoBehaviour
{
    public Vector3 destination;
    public float speed = 3f;
    public bool reachedDestination = false;

    Vector3 velocity;
    float distanceToDestination;

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        velocity = speed * (destination - transform.localPosition).normalized;
        distanceToDestination = (destination - transform.localPosition).magnitude;
        reachedDestination = false;
    }

    private void Update()
    {
        if (reachedDestination)
        {
            velocity = Vector3.zero;
        }
        else
        {
            transform.localPosition += velocity * Time.deltaTime;
            distanceToDestination -= speed * Time.deltaTime;
            if(distanceToDestination <= 0)
            {
                reachedDestination = true;
            }
        }
    }
}
