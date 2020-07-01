using UnityEngine;

public class GameManager : MonoBehaviour
{
    public VisualiserHandler visualizer;

    public float timeToStop = 60f;

    public void StartSimulation()
    {
        visualizer.agentSpawner.StartSimulation();
    }

    public void StopSimulation()
    {
        visualizer.agentSpawner.StopSimulation();
    }
}
