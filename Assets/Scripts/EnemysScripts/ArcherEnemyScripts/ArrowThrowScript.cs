using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowThrowScript : MonoBehaviour
{
    [SerializeField] GameObject m_arrowPrefab;
    [SerializeField] float m_throwDelay = 2f;
    [SerializeField] float m_throwForce = 10f;
    [SerializeField] Transform m_throwTarget;
    [SerializeField] private GameObject m_throwPoint;

    public bool m_canThrow = true;
    // Start is called before the first frame update
    void Start()
    {
        m_throwTarget = GameObject.FindGameObjectWithTag("Player").transform;
        if (m_canThrow)
            StartCoroutine(ThrowArrow());
    }
    
    void CantThrow()
    {
        m_canThrow = false;
    }
    
    IEnumerator ThrowArrow () 
    {
        GameObject bomb = Instantiate(m_arrowPrefab, m_throwPoint.transform.position, m_arrowPrefab.transform.rotation);
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        bomb.transform.LookAt(m_throwTarget);
        Vector3 direction = (m_throwTarget.position - transform.position).normalized;
        rb.AddForce(direction * m_throwForce, ForceMode.Impulse);
        yield return new WaitForSeconds(m_throwDelay);
        m_canThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
