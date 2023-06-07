using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShieldActivated : MonoBehaviour
{
    [SerializeField] Animator m_animatorShield;
    [SerializeField] Animator m_animatorCube;
    [SerializeField] WeaponChange m_weapon;
    [SerializeField] Rigidbody m_rb;
    [SerializeField] GroundCheck m_groundCheck;
    [SerializeField] CoolDownSliderScript m_coolDownSliderScript;
    [SerializeField] HpSystem m_hpSystem;
    [SerializeField] private AudioSource m_shieldSound;
    public bool m_canActive = false;
    
    

    // Start is called before the first frame update
    void Start()
    {

    }

    void BlockMoveON()
    {
        m_rb.isKinematic = true;
        m_weapon.enabled = false;
        m_canActive = true;
        m_hpSystem.m_isGetDamage = false;
    }

    void BlockMoveOff()
    {
        m_rb.isKinematic = false;
        m_weapon.enabled = true;
        m_canActive = false;
        m_hpSystem.m_isGetDamage = true;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && m_groundCheck.isGrounded == true && m_canActive == false && m_coolDownSliderScript.m_shieldCooldownClass.m_canAttack == true)
        {
            m_shieldSound.Play();
            m_animatorCube.SetTrigger("CubeUse");
            m_animatorShield.SetTrigger("Apear");
        }
    }
}
