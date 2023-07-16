using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSituationsController : MonoBehaviour
{
    public List<GameObject> m_situationsList = new List<GameObject>();

    private void Start()
    {
        GameObject situation = m_situationsList[UnityEngine.Random.Range(0, m_situationsList.Count)];
        situation.SetActive(true);
    }
}
