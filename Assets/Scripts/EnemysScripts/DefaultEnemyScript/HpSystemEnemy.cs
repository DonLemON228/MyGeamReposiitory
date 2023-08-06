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
    [SerializeField] int m_fallDamage = 5;
    //[SerializeField] private FirstPersonMovement m_personMovement;
    [SerializeField] private GameObject m_particleSystem;
    [SerializeField] private LevelController m_lvlController;
    [SerializeField] private bool m_isBossEnemy;
    [SerializeField] BossPhaze1AttackScript m_bossAttackScript;
    //[SerializeField] private EnemyLevelSpawnScript m_spawnScript;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetBarValue(currentHealth, maxHealth);
        //m_personMovement = FindObjectOfType<FirstPersonMovement>();
        m_bossAttackScript = FindObjectOfType<BossPhaze1AttackScript>();

    }

    /*public void SetSpawner(EnemyLevelSpawnScript _spawnScript)
    {
        m_spawnScript = _spawnScript;
    }*/

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
            animator.SetBool("Death", true);
            if(m_isBossEnemy)
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
            DestroyObject();
        }
    }
}


