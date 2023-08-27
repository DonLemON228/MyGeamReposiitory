using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSystemBossAssistant : MonoBehaviour
{
    public int maxHealth;
    public HealthBar healthBar;
    public float currentHealth;
    public Animator animator;
    public AudioSource deathSource;
    //public NavMeshAgent navMeshAgent;
    //public EnemyMove enemyMove;
    //public EnemyRotation enemyRotation;
    //[SerializeField] private FirstPersonMovement m_personMovement;
    [SerializeField] private GameObject m_particleSystem;
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] BossPhaze1AttackScript m_bossAttackScript;

    void Start()
    {
        //m_personMovement = FindObjectOfType<FirstPersonMovement>();
        m_bossAttackScript = FindObjectOfType<BossPhaze1AttackScript>();
        currentHealth = maxHealth;
        healthBar.SetBarValue(currentHealth, maxHealth);
    }

    private void DestroyObject()
    {
        Instantiate(m_particleSystem, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    //void BlockMove()
    //{
    //navMeshAgent.enabled = false;
    //enemyMove.enabled = false;
    //enemyRotation.enabled = false;
    //}

    public void GetDamage(int _count)
    {
        if (currentHealth <= 0)
        {
            m_rb.isKinematic = true;
            //deathSource.Play();
            animator.SetBool("Death", true);
            m_bossAttackScript.m_assistantCounterCurrent++;
        }
        else
        {
            //animator.SetTrigger("Damage");
            currentHealth -= _count;
            healthBar.SetBarValue(currentHealth, maxHealth);
            //m_personMovement.m_currentDamage += _count;
        }
    }

    public void Heal(int _count)
    {
        currentHealth += _count;
        healthBar.SetBarValue(currentHealth, maxHealth);
    }
}
