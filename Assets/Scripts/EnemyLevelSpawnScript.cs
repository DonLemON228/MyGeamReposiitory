using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelSpawnScript : MonoBehaviour
{
    [SerializeField] bool m_defaultAndMolotEnemy;
    [SerializeField] bool m_archer;
    [SerializeField] bool m_bombEnemy;
    [SerializeField] List<Enemy> m_roomEnemies = new List<Enemy>();
    [SerializeField] List<GameObject> m_points = new List<GameObject>();
    private int randomNumber;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
