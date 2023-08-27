using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSaveService
{
    public void SaveLvlProgres(SceneEnums _lvl, bool _isAvailable)
    {
        PlayerPrefs.SetString(_lvl.ToString(), _isAvailable.ToString());
        Debug.Log(GetLvlProgres(_lvl));
    }

    public bool GetLvlProgres(SceneEnums _lvl)
    {
        var lvlAvailableString = PlayerPrefs.GetString(_lvl.ToString());
        bool lvlAvailableBool;

        if(lvlAvailableString == "True")
            lvlAvailableBool = true;
        else
            lvlAvailableBool = false;

        return lvlAvailableBool;
    }
}
