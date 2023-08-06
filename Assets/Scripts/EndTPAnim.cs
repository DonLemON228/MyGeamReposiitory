using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTPAnim : MonoBehaviour
{
    [SerializeField] private Animator m_canvasAnim;
    [SerializeField] private HpSystem m_playerHpSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            m_canvasAnim.SetTrigger("Light");
            m_playerHpSystem.BlockMove();
        }
    }
}
