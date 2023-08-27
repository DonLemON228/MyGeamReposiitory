using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var enemyRigiBody = other.transform.GetComponent<Rigidbody>();
            var enemyFallDamageScript = other.transform.GetComponent<FallDamage>();
            other.transform.GetComponent<CapsuleCollider>().isTrigger = false;
            enemyFallDamageScript.m_canGetDamage = true;
            enemyFallDamageScript.m_enemyColider.isTrigger = false;
            enemyRigiBody.useGravity = true;
            var enemyAnim = other.transform.GetComponent<Animator>();
            enemyAnim.SetBool("Falling 0", true);
        }

        if (other.gameObject.tag == "EnemyArcher")
        {
            var enemyRigiBody = other.transform.GetComponent<Rigidbody>();
            var enemyFallDamageScript = other.transform.GetComponent<FallDamageArcher>();
            other.transform.GetComponent<CapsuleCollider>().isTrigger = false;
            enemyFallDamageScript.m_canGetDamage = true;
            enemyRigiBody.useGravity = true;
            var enemyAnim = other.transform.GetComponent<Animator>();
            enemyAnim.SetBool("Falling 0", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
