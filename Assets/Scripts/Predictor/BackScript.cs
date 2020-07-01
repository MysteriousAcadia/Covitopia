using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackScript : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
