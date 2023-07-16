using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyLevelSpawnScript : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public event Action m_onEnemySpawn;
    public event Action m_onEnemyDied;
    private LevelController m_lvlController;

    private void Start()
    {
        GenerateEnemy();
    }

    /*public void SetLevelController(LevelController _levelController)
    {
        m_lvlController = _levelController;
    }*/

    /*public void InvokeEnemyDieEvent()
    {
        m_onEnemyDied.Invoke();
    }*/

    public void GenerateEnemy()
    {
        foreach(var point in spawnPoints)
        {
            GameObject enemyPrefab = enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Count)];
            Instantiate(enemyPrefab, point.position, Quaternion.identity);
            //enemyPrefab.GetComponent<HpSystemEnemy>().SetSpawner(this);
            //m_onEnemySpawn.Invoke();
        }
    }
}
