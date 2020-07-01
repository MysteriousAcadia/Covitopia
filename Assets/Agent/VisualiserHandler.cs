using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisualiserHandler : MonoBehaviour
{
    public List<int> total, infected, fit, recovered, dead;
    public int currentTotal, currentInfected, currentFit, currentDead;

    bool keepSimulating = true;

    public AgentSpawner agentSpawner;

    private void Awake()
    {
        currentTotal = currentInfected = currentFit = currentDead = 0;
    }
}
