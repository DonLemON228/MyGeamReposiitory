using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketAttackScript : MonoBehaviour
{
    [SerializeField] GameObject m_attackPoint;
    [SerializeField] GameObject m_fish;
    [SerializeField] Animator m_bucketAnim;
    [SerializeField] float m_throwForce = 10f;
    [SerializeField] float firstRate = 1f;
    private float nextFire = 0f;

    void Attack()
    {
        Vector3 direction = m_attackPoint.transform.forward;
        GameObject fish = Instantiate(m_fish, transform.position, Quaternion.identity);
        fish.transform.rotation = Quaternion.LookRotation(m_attackPoint.transform.forward);
        fish.GetComponent<Rigidbody>().AddForce(direction * m_throwForce, ForceMode.Impulse);
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / firstRate;
            m_bucketAnim.SetTrigger("Attack");
        }
    }
}
