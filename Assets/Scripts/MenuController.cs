using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] Animator levelChooseAnim;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void levelChooseMenu()
    {
        levelChooseAnim.SetBool("ChooseLevel", true);
    }

    public void levelChooseMenuBack()
    {
        levelChooseAnim.SetBool("ChooseLevel", false);
    }

    public void Level1TP()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2TP()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3TP()
    {
        SceneManager.LoadScene(3);
    }

    public void Level4TP()
    {
        SceneManager.LoadScene(4);
    }

    public void Level5TP()
    {
        SceneManager.LoadScene(5);
    }

    public void Level6TP()
    {
        SceneManager.LoadScene(6);
    }

    public void Level7TP()
    {
        SceneManager.LoadScene(7);
    }

    public void Level8TP()
    {
        SceneManager.LoadScene(8);
    }

    public void Level9TP()
    {
        SceneManager.LoadScene(9);
    }

    public void Level10TP()
    {
        SceneManager.LoadScene(10);
    }
}
