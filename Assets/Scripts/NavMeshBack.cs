using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class NavMeshBack : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public EnemyMove enemyMove;
    [SerializeField] bool m_isArcher;
    public ArcherMove m_archerMove;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;
    public bool m_canBackNavMesh;
    public bool m_isBossEnemy;
    public GameObject ground;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        if(m_isArcher)
            m_archerMove = GetComponent<ArcherMove>();
        else
            enemyMove = GetComponent<EnemyMove>();

        if (m_isBossEnemy)
            ground = GameObject.FindWithTag("Ground");
    }

    private void CheckGround()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            if (m_canBackNavMesh)
            {
                navMeshAgent.enabled = true;
                if (m_isArcher)
                    m_archerMove.enabled = true;
                else
                    enemyMove.enabled = true;
            }
        }
        else
        {
            if (m_canBackNavMesh == false)
            {
                navMeshAgent.enabled = false;
                if (m_archerMove)
                    m_archerMove.enabled = false;
                else
                    enemyMove.enabled = false;
            }
            if (Vector3.Distance(transform.position, ground.transform.position) > 20)
            {
                navMeshAgent.enabled = false;
            }
        }
    }
    private void Update()
    {
        CheckGround();
    }

}
