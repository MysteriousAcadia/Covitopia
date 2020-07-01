using UnityEngine;

public enum CurrentPersonStates
{
    Fit,
    Infected,
    Recovered,
}

public abstract class Person
{
    public Person(PersonStateMachine personMachine)
    {
        this.personStateHandler = personMachine;
    }

    //Current State Identifier
    public CurrentPersonStates CurrentPersonState;
    
    //The probablity of a person to infect someone else
    public float probablityToInfect;
    //The probablity of a person to 
    public float probablityToBeInfected;

    public bool isMasked, willShakeHand;
    [Range(0, 1)]
    public float hygieneStandard, healthStandard, safetyStandard;

    public PersonStateMachine personStateHandler;

    public virtual void HandleProximity(Person other)
    {
        
    }
}
