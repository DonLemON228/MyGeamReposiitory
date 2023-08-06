using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class FallDamageArcher : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent navMeshAgent;
    public ArcherMove enemyMove;
    public EnemyRotation enemyRotation;
    public bool m_canGetDamage = false;
    [SerializeField] int m_fallDamage = 5;
    [SerializeField] HpSystemEnemy m_hpSystem;
    //[SerializeField] private FirstPersonMovement m_personMovement;

    private async void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 15 && m_canGetDamage)
        {
            animator.SetBool("Falling 0", false);
            m_hpSystem.currentHealth -= m_fallDamage;
            //m_personMovement.m_currentDamage += m_fallDamage;
            m_hpSystem.healthBar.SetBarValue(m_hpSystem.currentHealth, m_hpSystem.maxHealth);
            await Task.Delay(1000);
            m_canGetDamage = false;
            navMeshAgent.enabled = true;
            enemyMove.enabled = true;
        }
        else
        {
            navMeshAgent.enabled = true;
            enemyMove.enabled = true;
        }
    }
}
