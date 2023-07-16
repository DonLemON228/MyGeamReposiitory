using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Threading.Tasks;

public class RepulsiveField : MonoBehaviour
{

    public Animator animatorSphere;
    public WeaponChange weapon;
    public FirstPersonMovement firstPersonMovement;
    public Crouch crouch;
    public Jump jump;
    public GroundCheck groundCheck;
    public SphereCollider collider;
    public bool canActive = true;
    [SerializeField] int explosionDamage;
    [SerializeField] CoolDownSliderScript coolDownSliderScript;
    [SerializeField] private AudioSource m_explosionSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    async void Exploision()
    {
        Collider[] hitColiders = Physics.OverlapSphere(transform.position, 40.0f);

        foreach (var iter in hitColiders)
        {
            var rigidbody = iter.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(700.0f, transform.position, 40.0f, 1.3f);
            }
        }
    }

    void SoundActivate()
    {
        m_explosionSound.Play();
    }

    void BlockMoveON()
    {
        firstPersonMovement.enabled = false;
        crouch.enabled = false;
        jump.enabled = false;
        weapon.enabled = false;
        canActive = true;
        
    }

    async void ColliderOn()
    {
        collider.enabled = true;
        await Task.Delay(100);
        collider.enabled = false;

    }

    void BlockMoveOff()
    {
        firstPersonMovement.enabled = true;
        crouch.enabled = true;
        jump.enabled = true;
        weapon.enabled = true;
        canActive = false;
        collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var navMesh = other.gameObject.GetComponent<NavMeshAgent>();
            var moveScript = other.gameObject.GetComponent<EnemyMove>();
            other.GetComponent<HpSystemEnemy>().GetDamage(explosionDamage);
            moveScript.enabled = false;
            navMesh.enabled = false;
        }
    }


    // Update is called once per frame
    async void Update()
    {
        if (Input.GetButtonDown("Fire1") && groundCheck.isGrounded == true && canActive == false && coolDownSliderScript.m_explosionCooldownClass.m_canAttack == true)
        {
            animatorSphere.SetTrigger("CanAttack");
        }
    }
}
