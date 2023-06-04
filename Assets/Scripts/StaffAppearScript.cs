using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffAppearScript : MonoBehaviour
{
    [SerializeField] ParticleSystem m_particleSystem;
    [SerializeField] Phaze2Attack3Script m_phaze2Attack3Script;

    private void Start()
    {
        m_phaze2Attack3Script = FindObjectOfType<Phaze2Attack3Script>();
    }

    void ParticleSystemON()
    {
        m_particleSystem.Play();
    }

    void SpawnRandomStaff()
    {
        m_phaze2Attack3Script.SpawnAttack();
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
