using UnityEngine;

public class Infected : Person
{
    float probablityToRecover;
    int contacted;
    public Infected(PersonStateMachine personMachine): base(personMachine)
    {
        hygieneStandard = UIConfigSimulation.hygiene;
        healthStandard = UIConfigSimulation.health;
        isMasked = UIConfigSimulation.mask;
        willShakeHand = UIConfigSimulation.handShake;
        CurrentPersonState = CurrentPersonStates.Infected;
        safetyStandard = 0;
        safetyStandard += (isMasked) ? .5f : 0;
        safetyStandard += (willShakeHand) ? .5f : 0;

        probablityToInfect = 1 - (healthStandard + hygieneStandard + safetyStandard) / 3f;
        probablityToBeInfected = 0;
        probablityToRecover = .5f;
        contacted = 0;
    }

    public override void HandleProximity(Person other)
    {
        base.HandleProximity(other);

        contacted++;
        if(contacted > 5)
        {
            if(Random.Range(0f,1f) < probablityToRecover)
            {
                personStateHandler.SetState(new Recovered(personStateHandler));
                personStateHandler.visualiser.currentFit++;
                personStateHandler.visualiser.currentInfected--;
            }
            else
            {
                personStateHandler.visualiser.currentInfected--;
                personStateHandler.visualiser.currentDead++;
                personStateHandler.visualiser.currentTotal--;
                personStateHandler.DestroyAgent();
            }
        }
    }
}
