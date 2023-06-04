using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffApear : MonoBehaviour
{
    [SerializeField] Phaze2Attack2Script m_randomAttack;

    void GenerateNumber()
    {
        m_randomAttack.SetRandomAnim();
    }
}
