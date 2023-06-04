using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phaze2Attack2Script : MonoBehaviour
{
    public List<Animator> m_staffAnim = new List<Animator>();
    public int randomNumber = 0;

    public void SetRandomAnim()
    {
        m_staffAnim[randomNumber].SetTrigger("Activate");
        randomNumber = Random.Range(0, 7);
    }
}
