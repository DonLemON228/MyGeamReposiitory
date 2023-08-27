using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;


public class HpSystemEnemy : Enemy
{
    public int maxHealth;
    public HealthBar healthBar;
    public int currentHealth;
    public Animator animator;
    public AudioSource deathSource;
    [SerializeField] Collider m_enemyColider;
    [SerializeField] int m_fallDamage = 5;
    [SerializeField] EnemyRotation m_enemyRotation;
    //[SerializeField] private FirstPersonMovement m_personMovement;
    [SerializeField] private GameObject m_particleSystem;
    public LevelController m_lvlController;
    [SerializeField] private bool m_isBossEnemy;
    [SerializeField] BossPhaze1AttackScript m_bossAttackScript;
    private bool m_isDead;
    //[SerializeField] private EnemyLevelSpawnScript m_spawnScript;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetBarValue(currentHealth, maxHealth);
        //m_personMovement = FindObjectOfType<FirstPersonMovement>();
        m_enemyRotation = GetComponent<EnemyRotation>();
        m_bossAttackScript = FindObjectOfType<BossPhaze1AttackScript>();
    }

    /*public void SetSpawner(EnemyLevelSpawnScript _spawnScript)
    {
        m_spawnScript = _spawnScript;
    }*/

    void DestroyObject()
    {
        Destroy(gameObject);
        Instantiate(m_particleSystem, gameObject.transform.position, Quaternion.identity);
    }

    //void BlockMove()
    //{
        //navMeshAgent.enabled = false;
        //enemyMove.enabled = false;
        //enemyRotation.enabled = false;
    //}

    public void GetDamage(int _count)
    {
        if (m_isDead)
            return;

        if (currentHealth <= 0)
        {
            //deathSource.Play();
            m_isDead = true;
            m_enemyColider.enabled = false;
            animator.SetBool("Death", true);
            m_enemyRotation.enabled = false;
            if (m_isBossEnemy)
                m_bossAttackScript.m_assistantCounterCurrent++;
            else
                m_lvlController.m_currentEnemys--;
            //m_spawnScript.InvokeEnemyDieEvent();
            //+ т.к. здоровье будет отрицательным
        }
        else
        {
            currentHealth -= _count;
            //animator.SetTrigger("Damage");
            healthBar.SetBarValue(currentHealth, maxHealth);
            //m_personMovement.m_currentDamage += _count;
        }
    }

    public void Heal(int _count)
    {
        currentHealth += _count;
        healthBar.SetBarValue(currentHealth, maxHealth);
    }

    private void Update()
    {
        if (transform.position.y < -40)
        {
            GetDamage(currentHealth);
            GetDamage(1);
            DestroyObject();
        }
    }
}


