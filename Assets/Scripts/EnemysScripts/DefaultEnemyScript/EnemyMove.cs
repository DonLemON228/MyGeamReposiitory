using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] Animator animator;
    public GameObject player;
    private Vector3 startPosition;
    public int seeDistanse;
    public float attackDistance;
    public float m_defaultSpeed;


    async void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = transform.position;
        m_defaultSpeed = navAgent.speed;
        navAgent = GetComponent<NavMeshAgent>();
        await Task.Delay(100);
        navAgent.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) <= seeDistanse)
        {
            navAgent.destination = player.transform.position;
            animator.SetFloat("Speed", navAgent.speed);

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
