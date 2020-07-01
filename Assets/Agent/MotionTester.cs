using UnityEngine;

public class MotionTester : MonoBehaviour
{
    public AgentController testController;

    void Start()
    {
        testController.SetDestination(Vector3.one);
    }
}
