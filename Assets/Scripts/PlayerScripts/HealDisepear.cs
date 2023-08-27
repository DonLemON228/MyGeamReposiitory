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
    [SerializeField] private int m_healCount;
    [SerializeField] private List<GameObject> m_numberList = new List<GameObject>();
    [SerializeField] private bool m_isTutorial;
    [SerializeField] private GameObject m_doorTutorial;
    public event Action ThingHappened;

    // Start is called before the first frame update
    void Start()
    {
        m_numberList[0].SetActive(true);
        m_numberList[1].SetActive(false);
        m_numberList[2].SetActive(false);
        if (m_isTutorial)
            m_doorTutorial.GetComponent<Animator>().SetBool("Door", true);
    }

    public async void HealSphereOff()
    {
        m_healSound.Play();
        m_healStateAnim.SetBool("IsActive", true);
        m_collider.enabled = false;
        ThingHappened?.Invoke();
        m_healCount--;
        if (m_isTutorial)
            m_doorTutorial.GetComponent<Animator>().SetBool("Door", false);
        if (m_healCount > 0)
        {
            await Task.Delay(m_HealCooldown);
            m_collider.enabled = true;
            m_healStateAnim.SetBool("IsActive", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_healCount == 2)
        {
            m_numberList[0].SetActive(false);
            m_numberList[1].SetActive(true);
        }
        else if (m_healCount == 1)
        {
            m_numberList[1].SetActive(false);
            m_numberList[2].SetActive(true);
        }
        else if (m_healCount == 0)
        {
            m_numberList[0].SetActive(false);
            m_numberList[1].SetActive(false);
            m_numberList[2].SetActive(false);
        }
    }
}
