using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenSoundScript : MonoBehaviour
{
    [SerializeField] AudioSource m_doorSound;

    void PlaySound()
    {
        m_doorSound.Play();
    }
}
