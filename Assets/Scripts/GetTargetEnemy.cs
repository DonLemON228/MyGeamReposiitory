using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTargetEnemy : MonoBehaviour
{
    [SerializeField] List<Animator> m_enemyAnimatorsList;
    [SerializeField] List<Animator> m_doorsAnim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            foreach (var enemies in m_enemyAnimatorsList)
            {
                enemies.SetTrigger("Poklon");
            }
        }
    }
}
