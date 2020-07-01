using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonHandler : MonoBehaviour
{
    public void GoToSimulator()
    {
        SceneManager.LoadScene("SampleCity");
    }

    public void GoToPredictor()
    {
        SceneManager.LoadScene("PredictionScene");
    }

    public void GoToSocDist()
    {
        SceneManager.LoadScene("socialDistancing");
    }
}
