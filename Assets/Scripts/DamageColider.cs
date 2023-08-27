using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColider : MonoBehaviour
{
    [SerializeField] bool m_isStopJump;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (m_isStopJump)
            {
                other.GetComponent<Jump>().enabled = false;
                Destroy(gameObject);
            }
            else
            {
                other.GetComponent<HpSystem>().GetDamage(2);
                Destroy(gameObject);
            }
           
        }
    }
}
