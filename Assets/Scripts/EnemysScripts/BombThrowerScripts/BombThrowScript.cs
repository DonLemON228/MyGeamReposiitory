using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BombThrowScript : MonoBehaviour
{
    [SerializeField] GameObject m_bombPrefab;
    [SerializeField] float m_throwDelay = 2f;
    [SerializeField] float m_throwForce = 10f;
    [SerializeField] Transform m_throwTarget;
    [SerializeField] private GameObject m_throwPoint;
    public bool m_canThrow = true;

    private void Start()
    {
        m_throwTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Attack() 
    {
        if (m_canThrow)
            StartCoroutine(ThrowBomb());
    }

    void CantThrow()
    {
        m_canThrow = false;
    }
    
    IEnumerator ThrowBomb () 
    {
        GameObject bomb = Instantiate(m_bombPrefab, m_throwPoint.transform.position, Quaternion.identity);
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        Vector3 direction = (m_throwTarget.position - transform.position).normalized;
        rb.AddForce(direction * m_throwForce, ForceMode.Impulse);
        yield return new WaitForSeconds(m_throwDelay);
        m_canThrow = true;
    }
}
