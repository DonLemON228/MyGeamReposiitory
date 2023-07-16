using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Slider = UnityEngine.UIElements.Slider;


public class HpSystem : MonoBehaviour
{
    public int maxHealth;
    public HealthBar healthBar;
    public int currentHealth;
    public Animator animator;
    public Animator deathAnimator;
    public AudioSource damageSource;
    public ParticleSystem healParticle;
    public CheckPoint m_checkPoint;
    public CameraShake m_cameraShake;
    public bool m_isGetDamage = true;
    [SerializeField] FirstPersonMovement m_firstPersonMovement;
    [SerializeField] FirstPersonLook m_firstPersonLook;
    [SerializeField] WeaponChange m_weaponChange;
    [SerializeField] Jump m_jump;
    [SerializeField] Crouch m_crouch;
    [SerializeField] Collider m_playerColider;
    [SerializeField] Rigidbody m_playerRigibody;
    [SerializeField] ConeAttack m_coneAttack;
    [SerializeField] ShieldActivated m_shieldActivate;
    [SerializeField] RepulsiveField m_repulsiveField;
    [SerializeField] AntiGravityStaff m_staff;
    [SerializeField] int m_sceneNumber;
    [SerializeField] int m_diesCountCurrent;
    [SerializeField] int m_diesCountMax;
    [SerializeField] private HealDisepear subjectToObserve;

    void Start()
    {
        m_diesCountCurrent = 0;
        currentHealth = maxHealth;
        healthBar.SetBarValue(currentHealth, maxHealth);
    }

    private void OnThingHappened()
    {
        // any logic that responds to event goes here
        Debug.Log("off");
    }

    private void Awake()
    {
        if (subjectToObserve != null)
        {
            subjectToObserve.ThingHappened += OnThingHappened;
        }
    }

    void BlockMove()
    {
        m_firstPersonMovement.enabled = false;
        m_firstPersonLook.enabled = false;
        m_weaponChange.enabled = false;
        m_jump.enabled = false;
        m_crouch.enabled = false;
        m_playerRigibody.isKinematic = true;
        m_playerColider.enabled = false;
        m_coneAttack.enabled = false;
        m_shieldActivate.enabled = false;
        m_repulsiveField.enabled = false;
        m_staff.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void UnblockMove()
    {
        m_firstPersonMovement.enabled = true;
        m_firstPersonLook.enabled = true;
        m_weaponChange.enabled = true;
        m_jump.enabled = true;
        m_crouch.enabled = true;
        m_playerRigibody.isKinematic = false;
        m_playerColider.enabled = true;
        m_coneAttack.enabled = true;
        m_shieldActivate.enabled = true;
        m_repulsiveField.enabled = true;
        m_staff.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GetDamage(int _count)
    {
        if (m_isGetDamage)
        {
            damageSource.Play();
            animator.SetTrigger("Damage");
            currentHealth -= _count;
            healthBar.SetBarValue(currentHealth, maxHealth);
            StartCoroutine(m_cameraShake.Shake(0.3f, 0.07f));
        }
        
        if (currentHealth <= 0)
        {
            deathAnimator.SetBool("Death", true);
            BlockMove();
            m_diesCountCurrent++;
        }

        //if(m_diesCountCurrent == m_diesCountMax)
        //{
            //SceneManager.LoadScene(m_sceneNumber);
        //}
    }

    public void Revival()
    {
        UnblockMove();
        Time.timeScale = 1;
        deathAnimator.SetBool("Death", false);
        transform.position = m_checkPoint.m_spawnPoint;
        currentHealth = maxHealth;
        healthBar.SetBarValue(currentHealth, maxHealth);

    }
    
    public void ReloadLevel()
    {
        SceneManager.LoadScene(m_sceneNumber);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            m_checkPoint = other.GetComponent<CheckPoint>();
        }
    }

    public void Heal(int healCount)
    {
        currentHealth += healCount;
        healParticle.Play();

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -40)
        {
            Revival();
            m_diesCountCurrent++;
        }
    }
}
