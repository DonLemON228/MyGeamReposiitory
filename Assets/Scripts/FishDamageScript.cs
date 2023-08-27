using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDamageScript : MonoBehaviour
{
    [SerializeField] GameObject m_particleSystem;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Target"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 direction = -contact.normal;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Instantiate(m_particleSystem, contact.point, rotation);
            Destroy(gameObject);
        }
    }
}
