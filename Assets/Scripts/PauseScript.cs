using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScript : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] KeyCode keyMenuPaused;
    public FirstPersonLook FirstPersonLook;

    private void Start()
    {
        panel.SetActive(false);
    }

    void ActiveMenu()
    {
        if (Input.GetKey(keyMenuPaused))
        {
            FirstPersonLook.enabled = false;
            Time.timeScale = 0;
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Resume()
    {
        FirstPersonLook.enabled = true;
        Time.timeScale = 1;
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        ActiveMenu();
    }
}
