using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AgentSpawner : MonoBehaviour
{
    public GameObject agentPrefab;

    public Transform waypointRoot;
    public int totalNumberToSpawn;

    public VisualiserHandler visualiser;

    public List<GameObject> agents;

    public void StartSimulation()
    {
        agents = new List<GameObject>();
        totalNumberToSpawn = Mathf.RoundToInt(UIConfigSimulation.spawnCount);
        StartCoroutine(Spawn());
    }

    public void StopSimulation()
    {
        StopAllCoroutines();
        foreach(GameObject obj in agents)
        {
            Destroy(obj);
        }
    }

    IEnumerator Spawn()
    {
        int count = 0;
        while (count < totalNumberToSpawn)
        {
            GameObject obj = Instantiate(agentPrefab);
            agents.Add(obj);
            Transform child = waypointRoot.GetChild(Random.Range(0, waypointRoot.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();

            obj.transform.position = child.position;

            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
