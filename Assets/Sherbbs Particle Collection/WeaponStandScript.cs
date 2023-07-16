using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponStandScript : MonoBehaviour
{
    [SerializeField] Animator m_standAnim;
    [SerializeField] BoxCollider m_collider;
    [SerializeField] private AudioSource m_activateSound;
    [SerializeField] private Animator m_doorAnim;

    private void Start()
    {
        m_doorAnim.SetBool("Door", true);

    }
    public void StandActivate()
    {
        m_activateSound.Play();
        m_standAnim.SetTrigger("Activate");
        m_collider.enabled = false;
        m_doorAnim.SetBool("Door", false);
    }
    
}
