using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTextHeal : MonoBehaviour
{

    public Animator startAnim;
    [SerializeField] bool m_isWeaponStand;

    private void Start()
    {
        if(!isActiveAndEnabled)
            startAnim = GameObject.FindGameObjectWithTag("PressE").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startAnim.SetBool("startOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startAnim.SetBool("startOpen", false);
        }
    }
}
