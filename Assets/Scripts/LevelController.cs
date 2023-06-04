using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int m_currentEnemys;
    [SerializeField] private int m_maxEnemys = 0;
    [SerializeField] private Animator m_doorAnim;
    
    void Update()
    {
        if (m_currentEnemys >= m_maxEnemys)
        {
            m_doorAnim.SetTrigger("Open");
        }
    }
}
