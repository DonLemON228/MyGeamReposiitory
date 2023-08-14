using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int m_currentEnemys;
    [SerializeField] private int m_maxEnemys = 0;
    [SerializeField] List<Animator> m_doorsAnim;
    [SerializeField] EnemyLevelSpawnScript m_enemySpawner;
    [SerializeField] Collider m_lvlColider;
    [SerializeField] GameObject m_arrowObject;

    private void Awake()
    {
        m_arrowObject.SetActive(false);
        m_currentEnemys = m_maxEnemys;
        //m_enemySpawner.SetLevelController(this);
        /*if (m_enemySpawner != null)
        {
            m_enemySpawner.m_onEnemySpawn += IncreaseEnemyCount;
            m_enemySpawner.m_onEnemyDied += DecreaseEnemyCount;
        }*/
    }

    //void IncreaseEnemyCount() => m_currentEnemys++;
    //void DecreaseEnemyCount() => m_currentEnemys--;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            foreach (var doors in m_doorsAnim)
            {
                doors.SetBool("Door", true);
                Destroy(m_lvlColider);
            }
                
    }

    void Update()
    {
        if (m_currentEnemys <= 0)
            foreach (var doors in m_doorsAnim)
            {
                doors.SetBool("Door", false);
                m_arrowObject.SetActive(true);
            }
    }
}
