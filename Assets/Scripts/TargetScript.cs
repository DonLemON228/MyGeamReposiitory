using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetScript : MonoBehaviour
{
    [SerializeField] GameObject m_colider;
    private int hitCountPlunger;
    private int hitCountBucket;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            hitCountBucket++;
        }
    }

    public void PlungerShoot()
    {
        hitCountPlunger++;
    }

    private void Update()
    {
        if(hitCountPlunger > 0 && hitCountBucket > 0)
        {
            m_colider.SetActive(true);
        }
    }
}
