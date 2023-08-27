using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstTutorialSceneScript : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            PlayerPrefs.SetInt("FirstTime", 1);
            SceneManager.LoadScene("Tutorial");
        }
    }
}
