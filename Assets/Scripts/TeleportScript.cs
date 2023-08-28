using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour
{
    [SerializeField] private int m_sceneNumber;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            /*var _lvlSaveService = ServiceLocator.Resolve<LevelSaveService>();
            if (m_sceneNumber == 2)
                _lvlSaveService.SaveLvlProgres(SceneEnums.Lvl2, true);
            if(m_sceneNumber == 3)
                _lvlSaveService.SaveLvlProgres(SceneEnums.Lvl3, true);
            if(m_sceneNumber == 4)
                _lvlSaveService.SaveLvlProgres(SceneEnums.Lvl4, true);
            if(m_sceneNumber == 5)
                _lvlSaveService.SaveLvlProgres(SceneEnums.Lvl5, true);
            if(m_sceneNumber == 6)
                _lvlSaveService.SaveLvlProgres(SceneEnums.Lvl6, true);
            if(m_sceneNumber == 7)
                _lvlSaveService.SaveLvlProgres(SceneEnums.Lvl7, true);
            if(m_sceneNumber == 8)
                _lvlSaveService.SaveLvlProgres(SceneEnums.Lvl8, true);
            if(m_sceneNumber == 9)
                _lvlSaveService.SaveLvlProgres(SceneEnums.Lvl9, true);
            if(m_sceneNumber == 10)
                _lvlSaveService.SaveLvlProgres(SceneEnums.BossLvl, true);*/
            UnlockLevel();
            SceneManager.LoadScene(m_sceneNumber);
        }
    }

    public void UnlockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
        }
    }

    void TeleportToMenu()
    {
        SceneManager.LoadScene(m_sceneNumber);
    }
}
