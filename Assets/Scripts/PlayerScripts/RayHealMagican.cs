using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayHealMagican : MonoBehaviour
{
    [SerializeField] int weaponHeal;
    [SerializeField] float weaponRange;
    [SerializeField] Transform rayOrigin;
    
    public void Hit()
    {
        RaycastHit HitInfo;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out HitInfo, weaponRange))
        {
            if (HitInfo.transform.gameObject.GetComponent<HpSystemEnemy>())
                HitInfo.transform.gameObject.GetComponent<HpSystemEnemy>().Heal(weaponHeal);
        }
    }
}
