using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    [SerializeField] List<GameObject> m_ballSpawnPointList = new List<GameObject>();
    [SerializeField] GameObject m_ballPrefab;
    [SerializeField] float m_throwForce = 10f;
    [SerializeField] Transform m_throwTarget;
    [SerializeField] bool m_isBallSpawner;

    private void Start()
    {
        
    }

    public void SpawnBall()
    {
        foreach (GameObject point in m_ballSpawnPointList)
        {
            if (m_isBallSpawner)
            {
                GameObject bomb = Instantiate(m_ballPrefab, point.transform.position, m_ballPrefab.transform.rotation);
                Rigidbody rb = bomb.GetComponent<Rigidbody>();
                Vector3 direction = (m_throwTarget.position - transform.position).normalized;
                rb.AddForce(direction * m_throwForce, ForceMode.Impulse);
            }
        }
    }
}
