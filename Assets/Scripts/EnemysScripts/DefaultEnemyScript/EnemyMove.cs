using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] Animator animator;
    [SerializeField] HpSystemEnemy m_hpSystemEnemy;
    public GameObject player;
    private Vector3 startPosition;
    public int seeDistanse;
    public float attackDistance;
    public float m_defaultSpeed;


    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = transform.position;
        m_defaultSpeed = navAgent.speed;
    }


    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) <= seeDistanse)
        {
            animator.SetFloat("Speed", navAgent.speed);
            navAgent.destination = player.transform.position;


                if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
                {
                    animator.SetBool("isShooting", true);
                }
                else
                {
                    animator.SetBool("isShooting", false);
                }

        }
        else
        {
            navAgent.destination = startPosition;
        }
    }
}
