using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public PersonStateMachine stateMachine;

    private void OnTriggerEnter(Collider collider)
    {
        CollisionHandler other = collider.GetComponent<CollisionHandler>();
        if (other != null)
        {
            stateMachine.HandleProximity(other.GetPerson());
        }
    }

    public Person GetPerson()
    {
        return this.stateMachine.state;
    }
}
