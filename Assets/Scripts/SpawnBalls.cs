using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    [SerializeField] List<GameObject> m_ballSpawnPointList = new List<GameObject>();
    [SerializeField] GameObject m_ballPrefab;

    private void Start()
    {
        
    }

    public void SpawnBall()
    {
        foreach (GameObject point in m_ballSpawnPointList)
        {
            Instantiate(m_ballPrefab, point.transform.position, m_ballPrefab.transform.rotation);
        }
    }
}
