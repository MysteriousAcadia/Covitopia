using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text totalText, fitText, infectedText, deadText;
    public VisualiserHandler visualiser;

    public void Update()
    {
        totalText.text = "Tot: " + visualiser.currentTotal.ToString();
        fitText.text = "Fit: " + visualiser.currentFit.ToString();
        infectedText.text = "Inf: " + visualiser.currentInfected.ToString();
        deadText.text = "Ded: " + visualiser.currentDead.ToString();
    }
}
