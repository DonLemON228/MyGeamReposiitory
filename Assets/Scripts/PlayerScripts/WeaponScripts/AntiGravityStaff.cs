using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Threading.Tasks;


public class AntiGravityStaff : MonoBehaviour
{
    public float range = 20f;
    public Transform bulletSpawn;
    public Camera _cam;
    public Animator animator;
    private float nextFire = 0f;
    public float force = 155;
    public GameObject slashColider;
    public ParticleSystem slash;
    public WeaponChange weapon;
    public bool canActive = true;
    [SerializeField] CoolDownSliderScript coolDownSliderScript;
    [SerializeField] private AudioSource m_attackSound;

    // Start is called before the first frame update
    void Start()
    {
        canActive = true;
        slashColider.SetActive(false);
    }

    void AttackTriggerON()
    {
        weapon.enabled = false;
        canActive = true;
    }

    void AttackSoundActivate()
    {
        m_attackSound.Play();
    }

    void AttackTriggerOFF()
    {
        weapon.enabled = true;
        canActive = false;
    }

    public async void Shoot()
    {
        slashColider.SetActive(true);
        await Task.Delay(100);
        slashColider.SetActive(false);
    }

    void Impact()
    {
        slash.Play();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && canActive == true && coolDownSliderScript.m_staffCooldownClass.m_canAttack == true)
        {
            animator.SetTrigger("Attack");
        }
    }
}
