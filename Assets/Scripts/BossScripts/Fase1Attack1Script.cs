using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase1Attack1Script : MonoBehaviour
{
    public List<Animator> m_lasersAnim = new List<Animator>();
    public int randomNumber = 0;

    // Start is called before the first frame update

    public void SetRandomAnim() 
    {
        m_lasersAnim[randomNumber].SetTrigger("Activate");
        randomNumber = Random.Range(0, 17);
    }
}
