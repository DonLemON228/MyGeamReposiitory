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

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            var playerHpSystem = other.transform.GetComponent<HpSystem>();
            playerHpSystem.GetDamage(m_damage);
            m_coneAttack.m_ballCounter++;
            Debug.Log("Ball Damage");
            Destroy(gameObject);
        }

        if (other.transform.tag == "Wall" || other.transform.tag == "Shield")
        {
            m_coneAttack.m_ballCounter++;
            Destroy(gameObject);
        }
    }
}
