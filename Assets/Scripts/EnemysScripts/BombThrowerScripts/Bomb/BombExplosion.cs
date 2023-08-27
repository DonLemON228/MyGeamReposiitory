using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] private Animator m_bombAnim;
    [SerializeField] private ParticleSystem m_particleSystem;
    [SerializeField] private AudioSource m_explosionSound;
    [SerializeField] bool m_isExplosionBall;
    [SerializeField] BossPhaze2AttackScript m_bossAttackScript;

    private void Start()
    {
        if(m_isExplosionBall)
        {
            m_bossAttackScript = FindObjectOfType<BossPhaze2AttackScript>();
        }
        else
        {
            Explosion();
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
        m_explosionSound.Play();
        m_bombAnim.SetTrigger("BOOM");
        await Task.Delay(1000);
        Destroy(gameObject);
    }
}
