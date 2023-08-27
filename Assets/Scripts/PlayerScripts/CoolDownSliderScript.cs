using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownSliderScript : MonoBehaviour
{
    [SerializeField] ShieldActivated m_shieldActivated;
    [SerializeField] RepulsiveField m_repulsiveField;
    [SerializeField] AntiGravityStaff m_staff;

    [SerializeField] GameObject m_shieldCoolDownObject;
    [SerializeField] Slider m_shieldCoolDownSlider;
    public CooldownClass m_shieldCooldownClass = new CooldownClass();

    [SerializeField] GameObject m_explosionCoolDownObject;
    [SerializeField] Slider m_explosionCoolDownSlider;
    public CooldownClass m_explosionCooldownClass = new CooldownClass();

    [SerializeField] GameObject m_staffCoolDownObject;
    [SerializeField] Slider m_staffCoolDownSlider;
    public CooldownClass m_staffCooldownClass = new CooldownClass();



    // Start is called before the first frame update
    void Start()
    {
        m_shieldCooldownClass.m_timeLeft = m_shieldCooldownClass.m_coolDownTime;
        m_shieldCooldownClass.m_canAttack = true;
        m_explosionCooldownClass.m_timeLeft = m_explosionCooldownClass.m_coolDownTime;
        m_explosionCooldownClass.m_canAttack = true;
        m_staffCooldownClass.m_timeLeft = m_staffCooldownClass.m_coolDownTime;
        m_staffCooldownClass.m_canAttack = true;
    }

    void ShieldSliderTimer()
    {
        m_shieldCoolDownSlider.value = m_shieldCooldownClass.m_timeLeft;
        m_shieldCooldownClass.m_gameTime += 1 * Time.deltaTime;

        if (m_shieldCooldownClass.m_gameTime >= 1)
        {
            m_shieldCooldownClass.m_timeLeft -= 1;
            m_shieldCooldownClass.m_gameTime = 0;
        }
    }

    void ExplosionSliderTimer()
    {
        m_explosionCoolDownSlider.value = m_explosionCooldownClass.m_timeLeft;
        m_explosionCooldownClass.m_gameTime += 1 * Time.deltaTime;

        if (m_explosionCooldownClass.m_gameTime >= 1)
        {
            m_explosionCooldownClass.m_timeLeft -= 1;
            m_explosionCooldownClass.m_gameTime = 0;
        }
    }

    void StaffSliderTimer()
    {
        m_staffCoolDownSlider.value = m_staffCooldownClass.m_timeLeft;
        m_staffCooldownClass.m_gameTime += 1 * Time.deltaTime;

        if (m_staffCooldownClass.m_gameTime >= 1)
        {
            m_staffCooldownClass.m_timeLeft -= 1;
            m_staffCooldownClass.m_gameTime = 0;
        }
    }

    IEnumerator ShieldCoolDown()
    {
        m_shieldCoolDownObject.SetActive(true);
        m_shieldCooldownClass.m_canAttack = false;
        yield return new WaitForSeconds(m_shieldCooldownClass.m_coolDownTime);
        m_shieldCooldownClass.m_canAttack = true;
        m_shieldCoolDownObject.SetActive(false);
    }

    IEnumerator ExplosionCoolDown()
    {
        m_explosionCoolDownObject.SetActive(true);
        m_explosionCooldownClass.m_canAttack = false;
        yield return new WaitForSeconds(m_explosionCooldownClass.m_coolDownTime);
        m_explosionCooldownClass.m_canAttack = true;
        m_explosionCoolDownObject.SetActive(false);
    }

    IEnumerator StaffCoolDown()
    {
        m_staffCoolDownObject.SetActive(true);
        m_staffCooldownClass.m_canAttack = false;
        yield return new WaitForSeconds(m_staffCooldownClass.m_coolDownTime);
        m_staffCooldownClass.m_canAttack = true;
        m_staffCoolDownObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_shieldActivated.m_canActive == true)
        {
            StartCoroutine(ShieldCoolDown());
        }
        if (m_shieldCooldownClass.m_canAttack == false)
        {
            ShieldSliderTimer();
        }
        else
        {
            m_shieldCooldownClass.m_timeLeft = m_shieldCooldownClass.m_coolDownTime;
        }

        if (m_repulsiveField.canActive == true)
        {
            StartCoroutine(ExplosionCoolDown());
        }
        if (m_explosionCooldownClass.m_canAttack == false)
        {
            ExplosionSliderTimer();
        }
        else
        {
            m_explosionCooldownClass.m_timeLeft = m_explosionCooldownClass.m_coolDownTime;
        }

        if (m_staff.m_canActive == true)
        {
            StartCoroutine(StaffCoolDown());
        }
        if (m_staffCooldownClass.m_canAttack == false)
        {
            StaffSliderTimer();
        }
        else
        {
            m_staffCooldownClass.m_timeLeft = m_staffCooldownClass.m_coolDownTime;
        }
    }
}
