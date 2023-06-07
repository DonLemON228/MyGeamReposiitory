using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamageScript : MonoBehaviour
{
    [SerializeField] private int m_damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            var playerHpSystem = other.GetComponent<HpSystem>();
            playerHpSystem.GetDamage(m_damage);
        }
    }
}
