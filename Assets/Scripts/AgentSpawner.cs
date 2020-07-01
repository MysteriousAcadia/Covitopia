using UnityEngine;
using System.Collections;

public class AgentSpawner : MonoBehaviour
{
    public GameObject agentPrefab;

    public Transform waypointRoot;
    public int totalNumberToSpawn;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int count = 0;
        while (count < totalNumberToSpawn)
        {
            GameObject obj = Instantiate(agentPrefab);
            Transform child = waypointRoot.GetChild(Random.Range(0, waypointRoot.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();

            obj.transform.position = child.position;

            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
