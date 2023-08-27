using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanGenerateAttackTrue : MonoBehaviour
{
    [SerializeField] BossGenerateAttackScript m_bossGenerateAttackScript;
    [SerializeField] GameObject m_portal;
    [SerializeField] AudioSource m_defaultMusic;
    void GenerateAttackTrue()
    {
        m_bossGenerateAttackScript.canGenerateAttack = true;
    }

    void StartMusic()
    {
        m_defaultMusic.Play();
    }

    void SpawnPortal()
    {
        m_portal.SetActive(true);
    }

    void GenerateAttackFunck()
    {
        m_bossGenerateAttackScript.GenerateRandomAttack();
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
