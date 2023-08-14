using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArcherMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] Animator animator;
    public Transform player;
    private Vector3 startPosition;
    public int seeDistanse;
    public float attackNearDistance;
    public float attackFarDistance;
    public float m_defaultSpeed;
    [SerializeField] private ArrowThrowScript m_arrowThrowScript;
    
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
        m_defaultSpeed = navAgent.speed;
    }
    
    void Update()
    {
        

        if (Vector3.Distance(transform.position, player.position) <= seeDistanse)
        {
            animator.SetFloat("Speed", navAgent.speed);
            navAgent.destination = player.transform.position;

            if (Vector3.Distance(transform.position, player.position) <= attackNearDistance && Vector3.Distance(transform.position, player.position) < attackFarDistance)
            {
                animator.SetBool("isShootingNear", true);
            }
            else
            {
                animator.SetBool("isShootingNear", false);
            }
            
            if (Vector3.Distance(transform.position, player.position) <= attackFarDistance && Vector3.Distance(transform.position, player.position) > attackNearDistance && m_arrowThrowScript.m_canThrow)
            {
                animator.SetBool("isShootingFar", true);
            }
            else
            {
                animator.SetBool("isShootingFar", false);
            }

        }
        else
        {
            navAgent.destination = startPosition;
        }
    }
}
