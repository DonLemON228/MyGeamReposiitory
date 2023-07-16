using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<HpSystem>().GetDamage(other.GetComponent<HpSystem>().currentHealth);
        }

        if(other.tag == "Enemy")
        {
            other.GetComponent<HpSystemEnemy>().GetDamage(other.GetComponent<HpSystem>().currentHealth);
        }
    }
}
