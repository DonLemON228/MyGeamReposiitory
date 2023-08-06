using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class NavMeshBack : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public EnemyMove enemyMove;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyMove = GetComponent<EnemyMove>();
    }

    private async void OnCollisionEnter(Collision collision)
    {
        navMeshAgent.enabled = true;
        enemyMove.enabled = true;
    }
}
