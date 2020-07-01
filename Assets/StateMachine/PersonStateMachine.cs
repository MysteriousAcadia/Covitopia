using UnityEngine;

public class PersonStateMachine : MonoBehaviour
{
    //A variable to hold the persons state
    public Person state;

    public Material[] stateMaterial;
    public MeshRenderer capsule;

    public bool initiallyInfected;

    public void SetState(Person _state)
    {
        this.state = _state;
        capsule.material = stateMaterial[(int)_state.CurrentPersonState];
    }

    public float radiusForInfection;

    private void Start()
    {
        initiallyInfected = Random.Range(0, 2) == 0;
        if (initiallyInfected)
        {
            this.SetState(new Infected(this));
        }
        else
        {
            this.SetState(new Fit(this));
        }
    }

    public void HandleProximity(Person other)
    {
        state.HandleProximity(other);
    }

    public PersonStateMachine GetPersonStateMachine()
    {
        return this;
    }
}
