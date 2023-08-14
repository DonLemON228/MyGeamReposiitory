using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] Animator levelChooseAnim;
    

    int m_lvlComplete;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        m_lvlComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void LevelChooseMenu()
    {
        levelChooseAnim.SetBool("ChooseLevel", true);
    }

    public void LevelChooseMenuBack()
    {
        levelChooseAnim.SetBool("ChooseLevel", false);
    }

    public void DelateSaves()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
