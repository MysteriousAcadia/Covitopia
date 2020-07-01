using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIConfigSimulation : MonoBehaviour
{
    public static float hygiene, health, spawnCount;
    public static bool mask, handShake;

    //Button config
    public Button startButton;
    public Text startButtonText;

    public GameManager gm;

    bool isStart = false;

    public void ToggleStartButton()
    {
        if (!isStart)
        {
            //PUT CODE TO START STUFF
            gm.StartSimulation();
            startButtonText.text = "STOP";
        }
        else
        {
            gm.StopSimulation();
            startButtonText.text = "START";
        }
        isStart = !isStart;
    }
    //Health slider config

    public Text healtText;
    public Slider healthSlider;
    public void OnHealthSliderChange(){
        health = healthSlider.value;
        healtText.text = ((float)Math.Round(health * 10f) / 10f).ToString();
        //Update code
    }



    public Text hygineText;
    public Slider hygineSlider;
    public void OnHygineSliderChange()
    {
        hygiene = hygineSlider.value;
            hygineText.text = ((float)Math.Round(hygiene * 10f) / 10f).ToString();
        //Update code
    }



    public Text spawnText;
    public Slider spawnSlider;
    public void OnSpawnSliderChange()
    {
        spawnCount = spawnSlider.value;
        spawnText.text = ((float)Math.Round(spawnCount * 10f) / 10f).ToString();
        //Update code
    }

    //Toggles
    public Toggle maskToggle, handToggle;

    public void isMaskToggle(bool temp)
    {
        mask = maskToggle.isOn;
    }
    public void isHandToggle(bool temp)
    {
        handShake = handToggle.isOn;
    }

}
