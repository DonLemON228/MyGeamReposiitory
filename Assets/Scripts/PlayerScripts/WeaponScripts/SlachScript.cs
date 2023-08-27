using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlachScript : MonoBehaviour
{
    public float m_gravityForseUp = 155;
    public float m_gravityForseBack = 50;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.transform.GetComponent<NavMeshBack>().m_canBackNavMesh = false;
            other.transform.GetComponent<NavMeshAgent>().enabled = false;
            other.transform.GetComponent<EnemyMove>().enabled = false;
            var enemyAnim = other.transform.GetComponent<Animator>();
            enemyAnim.SetTrigger("Floating");
            var enemyRigiBody = other.transform.GetComponent<Rigidbody>();
            enemyRigiBody.useGravity = false;
            enemyRigiBody.AddForce(-enemyRigiBody.transform.forward *  m_gravityForseBack);
            enemyRigiBody.AddForce(enemyRigiBody.transform.up *  m_gravityForseUp);
        }

        if (other.gameObject.tag == "EnemyArcher")
        {
            other.transform.GetComponent<NavMeshBack>().m_canBackNavMesh = false;
            other.transform.GetComponent<ArcherMove>().enabled = false;
            other.transform.GetComponent<NavMeshAgent>().enabled = false;
            var enemyAnim = other.transform.GetComponent<Animator>();
            enemyAnim.SetTrigger("Floating");
            var enemyRigiBody = other.transform.GetComponent<Rigidbody>();
            enemyRigiBody.useGravity = false;
            enemyRigiBody.AddForce(-enemyRigiBody.transform.forward * m_gravityForseBack);
            enemyRigiBody.AddForce(enemyRigiBody.transform.up * m_gravityForseUp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
