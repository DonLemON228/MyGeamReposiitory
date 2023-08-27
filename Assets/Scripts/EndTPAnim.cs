using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTPAnim : MonoBehaviour
{
    [SerializeField] private Animator m_canvasAnim;
    [SerializeField] private HpSystem m_playerHpSystem;
    [SerializeField] private AudioSource m_lightSound;
    [SerializeField] private AudioSource m_music;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            m_music.Stop();
            m_lightSound.Play();
            m_canvasAnim.SetTrigger("Light");
            m_playerHpSystem.BlockMove();
        }
    }
}
