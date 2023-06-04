using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MagicianMove : MonoBehaviour
{

    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] Animator animator;
    [SerializeField] private List<HpSystemEnemy> enemysList = new List<HpSystemEnemy>();
    [SerializeField] private int m_healCoolDown;
    [SerializeField] private Animator m_shieldAnim;
    [SerializeField] Rigidbody rb;
    [SerializeField] private HpSystemEnemy m_hpSystemMagician;
    private Vector3 startPosition;
    public float attackDistance;
    private int defaultEnemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        m_hpSystemMagician = GetComponent<HpSystemEnemy>();
        startPosition = transform.position;
    }

    void GoBackToPoint()
    {
        m_hpSystemMagician.enabled = false;
        navAgent.destination = startPosition;
        m_shieldAnim.SetBool("Activation", true);
    }
    
    IEnumerator StartHeal ()
    {
        m_hpSystemMagician.enabled = false;
        rb.isKinematic = true;
        yield return new WaitForSeconds(m_healCoolDown);
        foreach (var hpSystem in enemysList)
        {
            if (hpSystem.currentHealth <= 5)
            {
                m_hpSystemMagician.enabled = true;
                rb.isKinematic = false;
                m_shieldAnim.SetBool("Activation", false);
                animator.SetFloat("Speed", navAgent.speed);
                var enemyTransform = hpSystem.transform;
                var enemyNavMesh = hpSystem.GetComponent<NavMeshAgent>();
                var enemyMove= hpSystem.GetComponent<EnemyMove>();
                enemyNavMesh.speed = 0;
                navAgent.destination = enemyTransform.transform.position;
                if (Vector3.Distance(transform.position, enemyTransform.position) <= attackDistance)
                {
                    animator.SetBool("isShooting", true);
                    enemyNavMesh.speed = enemyMove.m_defaultSpeed;
                }
                else
                {
                    animator.SetBool("isShooting", false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StartHeal());
    }
}
