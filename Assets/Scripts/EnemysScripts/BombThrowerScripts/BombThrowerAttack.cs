using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombThrowerAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform m_player;
    [SerializeField] float m_attackDistance;
    [SerializeField] private BombThrowScript m_bombThrowScript;
    
    
    private void Update()
    {
        if (Vector3.Distance(transform.position, m_player.position) <= m_attackDistance && m_bombThrowScript.m_canThrow)
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }
}
