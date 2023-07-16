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
    public NavMeshAgent navMeshAgent;
    public EnemyMove enemyMove;
    public EnemyRotation enemyRotation;
    [SerializeField] int m_fallDamage = 5;
    [SerializeField] private FirstPersonMovement m_personMovement;
    [SerializeField] private GameObject m_particleSystem;
    [SerializeField] private LevelController m_lvlController;
    //[SerializeField] private EnemyLevelSpawnScript m_spawnScript;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetBarValue(currentHealth, maxHealth);
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyRotation = GetComponent<EnemyRotation>();
        enemyMove = GetComponent<EnemyMove>();
        m_personMovement = FindObjectOfType<FirstPersonMovement>();

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
            m_lvlController.m_currentEnemys--;
            //m_spawnScript.InvokeEnemyDieEvent();
            //+ т.к. здоровье будет отрицательным
        }
        else
        {
            currentHealth -= _count;
            animator.SetTrigger("Damage");
            healthBar.SetBarValue(currentHealth, maxHealth);
            m_personMovement.m_currentDamage += _count;
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

    //private async void OnCollisionEnter(Collision collision)
    //{
        //m_level = collision.gameObject.GetComponent<LevelController>();
       //if (collision.relativeVelocity.magnitude > 20)
        //{
            //m_personMovement.m_currentDamage += m_fallDamage;
            //currentHealth -= m_fallDamage;
            //healthBar.SetBarValue(currentHealth, maxHealth);
            //animator.SetBool("Falling 0", false);
            //await Task.Delay(1000);
            //navMeshAgent.enabled = true;
            //enemyMove.enabled = true;
        //}
        //else
        //{
            //navMeshAgent.enabled = true;
            //enemyMove.enabled = true;
        //}
    //}
}


