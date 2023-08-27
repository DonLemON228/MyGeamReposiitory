using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextColiderScript : MonoBehaviour
{
    [SerializeField] GameObject m_textObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            m_textObject.SetActive(true);
    }
}
