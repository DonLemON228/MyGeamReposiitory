using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class TrapScript : MonoBehaviour
{
    private async void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            other.GetComponent<HpSystem>().GetDamage(other.GetComponent<HpSystem>().currentHealth);
        }

        if(other.transform.tag == "Enemy" || other.transform.tag == "EnemyArcher")
        {
            other.GetComponent<HpSystemEnemy>().m_lvlController.m_currentEnemys--;
            other.GetComponent<Animator>().SetBool("Death", true);
            await Task.Delay(500);
        }
    }
}
