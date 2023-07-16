using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


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

    void BlockMoveON()
    {
        m_rb.isKinematic = true;
        m_weapon.enabled = false;
        m_canActive = true;
        m_hpSystem.m_isGetDamage = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var navMesh = other.gameObject.GetComponent<NavMeshAgent>();
            var moveScript = other.gameObject.GetComponent<EnemyMove>();
            moveScript.enabled = false;
            navMesh.enabled = false;
        }
    }

    void BlockMoveOff()
    {
        m_rb.isKinematic = false;
        m_weapon.enabled = true;
        m_canActive = false;
        m_hpSystem.m_isGetDamage = true;
        Collider[] hitColiders = Physics.OverlapSphere(transform.position, 40.0f);

        foreach (var iter in hitColiders)
        {
            var rigidbody = iter.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(700.0f, transform.position, 20.0f, 1.3f);
            }
        }
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
