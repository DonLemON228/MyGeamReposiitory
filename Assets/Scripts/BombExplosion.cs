using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] private Animator m_bombAnim;
    [SerializeField] private ParticleSystem m_particleSystem;
    [SerializeField] bool m_isExplosionBall;
    [SerializeField] BossAttackScript m_bossAttackScript;

    private void Start()
    {
        if(m_isExplosionBall == false)
        {
            Explosion();
        }
        else
        {
            m_bossAttackScript = FindObjectOfType<BossAttackScript>();
        }
    }

    void ParticleSystemON()
    {
        m_particleSystem.Play();
    }

    void BallDestroyCounter()
    {
        m_bossAttackScript.m_explosionBallCount++;
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    async void Explosion()
    {
        await Task.Delay(2000);
        m_particleSystem.Play();
        m_bombAnim.SetTrigger("BOOM");
        await Task.Delay(1000);
        Destroy(gameObject);
    }
}
