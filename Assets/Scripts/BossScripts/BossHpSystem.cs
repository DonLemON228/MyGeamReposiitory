using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHpSystem : MonoBehaviour
{
    public int maxHealth;
    public HealthBar healthBar;
    public float currentHealth;
    public bool m_isGetDamage = false;
    [SerializeField] Animator m_animator;
    [SerializeField] BossGenerateAttackScript m_bossAttackScript;
    [SerializeField] private FirstPersonMovement m_personMovement;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetBarValue(currentHealth, maxHealth);
    }

    public void GetDamage(int _count)
    {
        if (currentHealth <= 0)
        {
            return;
        }
        else
        {
            if (m_isGetDamage)
            {
                currentHealth -= _count;
                healthBar.SetBarValue(currentHealth, maxHealth);
                m_personMovement.m_currentDamage += _count;
            }
        }

        if(currentHealth <= 90 && m_bossAttackScript.m_isPhazeTwo == false)
        {
            m_animator.SetTrigger("Phase2");
            m_bossAttackScript.m_isPhazeTwo = true;
            m_isGetDamage = false;
            m_bossAttackScript.canGenerateAttack = true;
            //m_bossAttackScript.SpawnEnemyPhase2();
        }
    }
}
