using UnityEngine;

public class Recovered : Person
{
    public Recovered(PersonStateMachine personMachine): base(personMachine)
    {
        CurrentPersonState = CurrentPersonStates.Recovered;
        probablityToBeInfected = 0;
        probablityToInfect = 0;
    }

    private void Start()
    {
        
    }
}
