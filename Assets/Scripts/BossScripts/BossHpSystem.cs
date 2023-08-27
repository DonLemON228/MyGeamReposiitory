using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHpSystem : MonoBehaviour
{
    public int maxHealth;
    public HealthBar healthBar;
    public float currentHealth;
    public bool m_isGetDamage = false;
    [SerializeField] Animator m_bossObject;
    [SerializeField] Animator m_animator;
    [SerializeField] BossGenerateAttackScript m_bossAttackScript;
    [SerializeField] BossPhaze1AttackScript m_bossPhaze1AttackScript;
    //[SerializeField] private FirstPersonMovement m_personMovement;
    [SerializeField] private AudioSource m_defaultMusic;
    [SerializeField] private AudioSource m_endMusic;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetBarValue(currentHealth, maxHealth);
    }

    public void GetDamage(int _count)
    {
        if (currentHealth <= 0)
        {
            m_bossPhaze1AttackScript.StopAllCoroutines();
            m_bossAttackScript.canGenerateAttack = false;
            m_animator.SetBool("CanTakeDamage", false);
            m_animator.SetTrigger("Death");
            m_bossObject.SetTrigger("Death");
            m_defaultMusic.Stop();
            m_endMusic.Play();
        }
        else
        {
            if (m_isGetDamage)
            {
                currentHealth -= _count;
                healthBar.SetBarValue(currentHealth, maxHealth);
                //m_personMovement.m_currentDamage += _count;
            }
        }

        /*if(currentHealth <= 90 && m_bossAttackScript.m_isPhazeTwo == false)
        {
            m_animator.SetTrigger("Phase2");
            m_bossAttackScript.m_isPhazeTwo = true;
            m_isGetDamage = false;
            m_bossAttackScript.canGenerateAttack = true;
            //m_bossAttackScript.SpawnEnemyPhase2();
        }*/
    }
}
