using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamage : MonoBehaviour
{
    [SerializeField] private int m_damage;
    [SerializeField] ConeAttack m_coneAttack;

    private void Start()
    {
        m_coneAttack = FindObjectOfType<ConeAttack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            var playerHpSystem = other.GetComponent<HpSystem>();
            playerHpSystem.GetDamage(m_damage);
            m_coneAttack.m_ballCounter++;
            Destroy(gameObject);
        }

        if (other.transform.tag == "Wall")
        {
            m_coneAttack.m_ballCounter++;
            Destroy(gameObject);
        }
    }
}
