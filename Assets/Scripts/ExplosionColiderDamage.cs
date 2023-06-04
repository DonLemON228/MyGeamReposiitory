using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionColiderDamage : MonoBehaviour
{
    [SerializeField] private int m_explosionDamage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            var playerHpSystem = other.GetComponent<HpSystem>();
            playerHpSystem.GetDamage(m_explosionDamage);
        }
    }
}
