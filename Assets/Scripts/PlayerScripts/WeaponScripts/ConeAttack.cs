using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class ConeAttack : MonoBehaviour
{

    [SerializeField] float damage = 2f;
    [SerializeField] float firstRate = 1f;
    [SerializeField] float range = 20f;
    [SerializeField] float force = 155;
    [SerializeField] AudioClip shotSFX;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Camera _cam;
    [SerializeField] Animator animator;
    [SerializeField] GameObject hitEffectDefault;
    [SerializeField] int weaponDamage;
    public int m_ballCounter;
    private float nextFire = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /// <summary>
    /// нанемсение урона лучом
    /// </summary>
    async void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Ball")
            {
                m_ballCounter++;
                Destroy(hit.transform.gameObject);
                
            }
            _audioSource.PlayOneShot(shotSFX);
            var enemyNavMesh = hit.transform.GetComponent<NavMeshAgent>();

            GameObject impact = Instantiate(hitEffectDefault, hit.point, Quaternion.LookRotation(hit.normal));

            if (hit.transform.gameObject.GetComponent<HpSystemEnemy>())
                hit.transform.gameObject.GetComponent<HpSystemEnemy>().GetDamage(weaponDamage);
            if (hit.transform.gameObject.GetComponent<HpSystemBossAssistant>())
                hit.transform.gameObject.GetComponent<HpSystemBossAssistant>().GetDamage(weaponDamage);
            if (hit.transform.gameObject.GetComponent<BossHpSystem>())
                hit.transform.gameObject.GetComponent<BossHpSystem>().GetDamage(weaponDamage);
            //enemyNavMesh.enabled = false;
            //await Task.Delay(1100);
            //enemyNavMesh.enabled = true;
            Destroy(impact, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / firstRate;
            animator.SetTrigger("Attack");
        }
    }
}
