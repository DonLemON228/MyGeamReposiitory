using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Phaze2Attack3Script : MonoBehaviour
{
    [SerializeField] Transform m_player;
    [SerializeField] GameObject m_attackPrefab;

    private void Start()
    {
        SpawnAttack();
    }

    public void SpawnAttack()
    {
        Instantiate(m_attackPrefab, m_player.position, m_attackPrefab.transform.rotation);
    }
}
