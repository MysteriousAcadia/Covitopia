using UnityEngine;

public class PersonStateMachine : MonoBehaviour
{
    //A variable to hold the persons state
    public Person state;

    public Material[] stateMaterial;
    public MeshRenderer capsule;

    public VisualiserHandler visualiser;

    public bool initiallyInfected;

    public void SetState(Person _state)
    {
        this.state = _state;
        capsule.material = stateMaterial[(int)_state.CurrentPersonState];
    }

    public float radiusForInfection;

    private void Awake()
    {
        visualiser = FindObjectOfType<VisualiserHandler>();
    }

    private void Start()
    {
        initiallyInfected = Random.Range(0f, 2f) < .2f;
        if (initiallyInfected)
        {
            this.SetState(new Infected(this));
            visualiser.currentInfected++;
        }
        else
        {
            this.SetState(new Fit(this));
            visualiser.currentFit++;
        }

        visualiser.currentTotal++;
    }

    public void HandleProximity(Person other)
    {
        state.HandleProximity(other);
    }

    public PersonStateMachine GetPersonStateMachine()
    {
        return this;
    }

    public void DestroyAgent()
    {
        Destroy(gameObject);
    }
}
