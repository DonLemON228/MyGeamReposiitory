using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSoundScript : MonoBehaviour
{
    [SerializeField] List<AudioClip> m_sounds = new List<AudioClip>();
    [SerializeField] AudioSource m_audioSource;

    public void PlayRandomClip()
    {
        int randomNumber = Random.Range(0, m_sounds.Count);
        
    }
}
