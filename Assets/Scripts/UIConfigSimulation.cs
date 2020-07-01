using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIConfigSimulation : MonoBehaviour
{
    //Button config
    public Button startButton;
    public Text startButtonText;
    bool isStart = false;

    public void ToggleStartButton()
    {
        if (!isStart)
        {
            //PUT CODE TO START STUFF
            startButtonText.text = "STOP";
        }
        else
        {
            startButtonText.text = "START";
        }
        isStart = !isStart;
    }
    //Health slider config

    public Text healtText;
    public Slider healthSlider;
    public void OnHealthSliderChange(){
        float value = healthSlider.value;
        healtText.text = ((float)Math.Round(value * 10f) / 10f).ToString();
        //Update code
    }



public Text hygineText;
public Slider hygineSlider;
public void OnHygineSliderChange()
{
    float value = hygineSlider.value;
        hygineText.text = ((float)Math.Round(value * 10f) / 10f).ToString();
    //Update code
}



 public Text spawnText;
public Slider spawnSlider;
public void OnSpawnSliderChange()
{
    float value = spawnSlider.value;
    spawnText.text = ((float)Math.Round(value * 10f) / 10f).ToString();
    //Update code
}

    //Toggles
    public Toggle maskToggle, handToggle;

    public void isMaskToggle(bool temp)
    {
        bool value = maskToggle.isOn;
    }
    public void isHandToggle(bool temp)
    {
        bool value = handToggle.isOn;
    }

}
