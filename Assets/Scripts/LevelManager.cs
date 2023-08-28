using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int levelUnlock;
    [SerializeField] GameObject[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        levelUnlock = PlayerPrefs.GetInt("levels", 1);

        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }

        for (int i = 0; i < levelUnlock; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
