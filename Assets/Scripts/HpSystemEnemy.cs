using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HpSystemEnemy : Enemy
{
    public int maxHealth;
    public HealthBar healthBar;
    public float currentHealth;
    public Animator animator;
    public AudioSource deathSource;
    //public NavMeshAgent navMeshAgent;
    //public EnemyMove enemyMove;
    //public EnemyRotation enemyRotation;
    [SerializeField] private FirstPersonMovement m_personMovement;
    [SerializeField] private LevelController m_level;
    [SerializeField] private GameObject m_particleSystem;

    void Start()
    {
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
            //deathSource.Play();
            m_level.m_currentEnemys++;
            animator.SetBool("Death", true);
        }
        else
        {
            m_personMovement.m_currentDamage += _count;
            animator.SetTrigger("Damage");
            currentHealth -= _count;
            healthBar.SetBarValue(currentHealth, maxHealth);
        }
    }

    public void Heal(int _count)
    {
        currentHealth += _count;
        healthBar.SetBarValue(currentHealth, maxHealth);
    }

    //public void GetFallDamage(int _count)
    //{
        //damageSource.PlayOneShot(deathSound);
        //currentHealth -= _count;
        //healthBar.SetBarValue(currentHealth, maxHealth);
    //}
}


