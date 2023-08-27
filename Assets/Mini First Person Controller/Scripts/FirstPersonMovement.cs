using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 10;
    public KeyCode runningKey = KeyCode.LeftShift;
    private bool m_canRunAnim = true;
    public Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    [SerializeField] Animator cameraAnim;

    [SerializeField] Slider staminaSlider;
    [SerializeField] float staminaValue;
    [SerializeField] float minValueStamina;
    [SerializeField] float maxValueStamina;
    [SerializeField] float staminaReturn;
    //[SerializeField] private Slider m_damageSlider;
    //[SerializeField] private float m_minDamage = 0;
    //[SerializeField] private float m_maxDamage = 100f;
    //[SerializeField] private Animator m_speedUpAnimator;
    //[SerializeField] private bool m_canStopTime = true;
    //[SerializeField] private Animator m_timeStopAnim;
    //[SerializeField] private AudioSource m_timeStopStartSound;
    //[SerializeField] private AudioSource m_timeStopClockSound;
    //[SerializeField] private AudioSource m_SpeedUpSound;
    //public float m_currentDamage;
    //public CameraShake m_cameraShake;



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
        //m_currentDamage = m_minDamage;
        Time.timeScale = 1;
    }

    /*async void DamageSlider()
    {
        if (m_currentDamage > m_maxDamage)
        {
            m_currentDamage = m_maxDamage;
        }

        if (m_currentDamage == m_maxDamage && m_canStopTime == true)
        {
            m_canRunAnim = false;
            m_timeStopAnim.SetBool("TimeStop", true);
        }
    }*/

    /*void TimeStopShake()
    {
        m_timeStopStartSound.Play();
        StartCoroutine(m_cameraShake.Shake(2f, 0.06f));
    }*/

    /*void TimeStopAnimOn()
    {
        StartCoroutine(TimeStop());
    }*/

    /*IEnumerator TimeStop()
    {
        m_canStopTime = false;
        Time.timeScale = 0;
        m_timeStopClockSound.Play();
        yield return new WaitForSecondsRealtime(5f);
        m_timeStopAnim.SetBool("TimeStop", false);
        Time.timeScale = 1;
        m_speedUpAnimator.SetBool("SpeedUp", true);
        m_SpeedUpSound.Play();
        speed = 15;
        runSpeed = 15;
        m_canRunAnim = false;
        yield return new WaitForSecondsRealtime(10f);
        speed = 5;
        runSpeed = 10;
        m_canRunAnim = true;
        m_currentDamage = m_minDamage;
        m_canRunAnim = true;
        m_speedUpAnimator.SetBool("SpeedUp", false);
        m_canStopTime = true;
    }*/

    void FixedUpdate()
    {
        //m_damageSlider.value = m_currentDamage;
        Stamina();
        //DamageSlider();
        

        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey) && staminaValue > 0;

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);

        if (Input.GetKey(KeyCode.LeftShift) && staminaValue > 0 && m_canRunAnim == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                cameraAnim.SetBool("RunCamera", true);
                staminaValue -= staminaReturn * Time.deltaTime * 5;
            }
        }
        else
        {
            cameraAnim.SetBool("RunCamera", false);
            staminaValue += staminaReturn * Time.deltaTime * 10;
        }
    }

    private void Stamina()
    {
        if(staminaValue > maxValueStamina)
        {
            staminaValue = maxValueStamina;
        }
        staminaSlider.value = staminaValue;

        if((Input.GetKey(KeyCode.LeftShift) && staminaValue <= 0))
        {
            staminaReturn = 0;
        }
        else
        {
            staminaReturn = 2;

        }
    }
}