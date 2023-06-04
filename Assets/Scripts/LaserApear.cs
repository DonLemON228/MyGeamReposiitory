using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserApear : MonoBehaviour
{
    public ParticleSystem m_laserParticle;
    [SerializeField] Fase1Attack1Script m_randomAttack;

    void LaserParticleApear()
    {
        m_laserParticle.Play();
    }

    void GenerateNumber()
    {
        m_randomAttack.SetRandomAnim();
    }

    void LaserParticleDisapear()
    {
        m_laserParticle.Stop();
    }
}
