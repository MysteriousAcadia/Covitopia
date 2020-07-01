using UnityEngine;

public class Infected : Person
{
    float probablityToRecover;

    public Infected(PersonStateMachine personMachine): base(personMachine)
    {
        hygieneStandard = healthStandard = .5f;
        isMasked = Random.Range(0, 2) == 1 ? true : false;
        willShakeHand = Random.Range(0, 2) == 1 ? true : false;
        CurrentPersonState = CurrentPersonStates.Infected;
        safetyStandard = 0;
        safetyStandard += (isMasked) ? .5f : 0;
        safetyStandard += (willShakeHand) ? .5f : 0;

        probablityToInfect = 1 - (healthStandard + hygieneStandard + safetyStandard) / 3f;
        probablityToBeInfected = 0;
        probablityToRecover = .5f;
    }
}
