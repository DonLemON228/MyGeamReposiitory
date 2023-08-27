using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChangeTutorial : MonoBehaviour
{
    [SerializeField] List<GameObject> m_weapons = new List<GameObject>();
    [SerializeField] private RaiseTheIteam m_raiseTheIteam;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && m_raiseTheIteam.m_canUsePlunger)
        {
            m_weapons[0].SetActive(true);
            m_weapons[1].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && m_raiseTheIteam.m_canUseBucket)
        {
            m_weapons[1].SetActive(true);
            m_weapons[0].SetActive(false);
        }
    }
}
