using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{

    [SerializeField] GameObject Cone;
    [SerializeField] GameObject Shield;
    [SerializeField] GameObject RepulsiveField;
    [SerializeField] GameObject Staff;
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
            Cone.SetActive(true);
            Shield.SetActive(false);
            RepulsiveField.SetActive(false);
            Staff.SetActive(false);
            explosionParticle.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && m_raiseTheIteam.m_canUseShield == true)
        {
            Cone.SetActive(false);
            Shield.SetActive(true);
            RepulsiveField.SetActive(false);
            Staff.SetActive(false);
            explosionParticle.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && m_raiseTheIteam.m_canUseExplosion == true)
        {
            Cone.SetActive(false);
            Shield.SetActive(false);
            RepulsiveField.SetActive(true);
            Staff.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && m_raiseTheIteam.m_canUseStaff == true)
        {
            Cone.SetActive(false);
            Shield.SetActive(false);
            RepulsiveField.SetActive(false);
            Staff.SetActive(true);
            explosionParticle.SetActive(false);
        }
    }
}
