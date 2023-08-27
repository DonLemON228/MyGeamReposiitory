using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] GameObject electroRapier;
    [SerializeField] GameObject shield;
    [SerializeField] GameObject explosionSphere;
    [SerializeField] GameObject staff;
    [SerializeField] GameObject explosionParticle;
    [SerializeField] private RaiseTheIteam m_raiseTheIteam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            electroRapier.SetActive(true);
            shield.SetActive(false);
            explosionSphere.SetActive(false);
            staff.SetActive(false);
            explosionParticle.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && m_raiseTheIteam.m_canUseShield == true)
        {
            electroRapier.SetActive(false);
            shield.SetActive(true);
            explosionSphere.SetActive(false);
            staff.SetActive(false);
            explosionParticle.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && m_raiseTheIteam.m_canUseExplosion == true)
        {
            electroRapier.SetActive(false);
            shield.SetActive(false);
            explosionSphere.SetActive(true);
            staff.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && m_raiseTheIteam.m_canUseStaff == true)
        {
            electroRapier.SetActive(false);
            shield.SetActive(false);
            explosionSphere.SetActive(false);
            staff.SetActive(true);
            explosionParticle.SetActive(false);
        }
    }
}
