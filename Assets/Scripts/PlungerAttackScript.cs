using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerAttackScript : MonoBehaviour
{
    [SerializeField] float firstRate = 1f;
    [SerializeField] float range = 20f;
    [SerializeField] Camera _cam;
    [SerializeField] Animator animator;
    [SerializeField] GameObject hitEffectDefault;
    private float nextFire = 0f;

    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, range))
        {
            GameObject impact = Instantiate(hitEffectDefault, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);

            if(hit.collider.CompareTag("Target"))
                hit.transform.gameObject.GetComponent<TargetScript>().PlungerShoot();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / firstRate;
            animator.SetTrigger("Attack");
        }
    }
}
