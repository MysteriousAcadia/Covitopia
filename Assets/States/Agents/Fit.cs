using UnityEngine;

public class Fit : Person
{
    public Fit(PersonStateMachine personMachine): base(personMachine){
        hygieneStandard = healthStandard = .5f;
        isMasked = Random.Range(0, 2) == 1 ? true : false;
        willShakeHand = Random.Range(0, 2) == 1 ? true : false;
        CurrentPersonState = CurrentPersonStates.Fit;
        safetyStandard = 0;
        safetyStandard += (isMasked) ? .5f : 0;
        safetyStandard += (willShakeHand) ? .5f : 0;

        probablityToBeInfected = 1 - (healthStandard + hygieneStandard + safetyStandard) / 3f;
        probablityToInfect = 0;
    }

    private void Start()
    {
        
    }

    public override void HandleProximity(Person other)
    {
        base.HandleProximity(other);
        if(other.probablityToInfect > 0)
        {
            personStateHandler.SetState(new Infected(personStateHandler)); 
        }
    }
}
