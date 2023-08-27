using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class FallDamage : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent navMeshAgent;
    public EnemyMove enemyMove;
    public EnemyRotation enemyRotation;
    public NavMeshBack enemyNavMeshBack;
    public bool m_canGetDamage = false;
    public Collider m_enemyColider;
    [SerializeField] int m_fallDamage = 5;
    [SerializeField] HpSystemEnemy m_hpSystem;
    //[SerializeField] private FirstPersonMovement m_personMovement;

    private void Awake()
    {
        m_enemyColider = GetComponent<Collider>();
    }

    private async void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 15 && m_canGetDamage)
        {
            animator.SetBool("Falling 0", false);
            m_hpSystem.currentHealth -= m_fallDamage;
            //m_personMovement.m_currentDamage += m_fallDamage;
            m_hpSystem.healthBar.SetBarValue(m_hpSystem.currentHealth, m_hpSystem.maxHealth);
            navMeshAgent.enabled = false;
            enemyMove.enabled = false;
        }
    }

    void ColiderOff()
    {
        m_enemyColider.isTrigger = true;
    }

    void NavMeshBack()
    {
        enemyNavMeshBack.m_canBackNavMesh = true;
    }
}
