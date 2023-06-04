using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawnPointScript : MonoBehaviour
{
    private const int MAX_ENEMIES = 5;
    
    [SerializeField] EnemyMove m_enemyPrefab;
    [SerializeField] List<Transform> m_spwnPoints;
    [SerializeField] private float m_timeSpawn = 5f;
    List<EnemyMove> m_enemyList;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    void Spawn()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        if (m_enemyList.Count < MAX_ENEMIES)
        {
            yield return new WaitForSeconds(m_timeSpawn);
            //todo переделать под случайный спавн
            EnemyMove enemy = Instantiate(m_enemyPrefab, m_spwnPoints[0].position, Quaternion.identity);
            m_enemyList.Add(enemy);
            Spawn();
        }
    }
}
