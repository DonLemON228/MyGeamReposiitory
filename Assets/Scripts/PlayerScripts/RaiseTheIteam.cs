using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseTheIteam : MonoBehaviour
{

    [SerializeField] GameObject camera;
    [SerializeField] float distance = 15f;
    [SerializeField] HpSystem hp;
    public bool m_canUseShield = false;
    public bool m_canUseExplosion = false;
    public bool m_canUseStaff = false;



    void PickUp()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Heal")
            {
                if (hp.currentHealth < hp.maxHealth)
                {
                    hp.Heal(3);
                    hp.healthBar.SetBarValue(hp.currentHealth, hp.maxHealth);
                    hit.transform.GetComponent<HealDisepear>().HealSphereOff();
                }
                else
                {
                    return;
                }
            }

            if (hit.transform.tag == "ShieldStand")
            {
                m_canUseShield = true;
                hit.transform.GetComponent<WeaponStandScript>().StandActivate();
            }
            if (hit.transform.tag == "ExplosionStand")
            {
                m_canUseExplosion = true;
                hit.transform.GetComponent<WeaponStandScript>().StandActivate();
            }
            if (hit.transform.tag == "StaffStand")
            {
                m_canUseStaff = true;
                hit.transform.GetComponent<WeaponStandScript>().StandActivate();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }
}
