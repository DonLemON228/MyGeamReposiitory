using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class HealDisepear : MonoBehaviour
{

    [SerializeField] Animator m_healStateAnim;
    [SerializeField] SphereCollider m_collider;
    [SerializeField] int m_HealCooldown;
    [SerializeField] private AudioSource m_healSound;
    public event Action ThingHappened;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public async void HealSphereOff()
    {
        m_healSound.Play();
        m_healStateAnim.SetBool("IsActive", true);
        m_collider.enabled = false;
        ThingHappened?.Invoke();
        await Task.Delay(m_HealCooldown);
        m_collider.enabled = true;
        m_healStateAnim.SetBool("IsActive", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
