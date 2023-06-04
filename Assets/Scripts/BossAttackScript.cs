using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BossAttackScript : MonoBehaviour
{
    [SerializeField] Animator m_bossAnim;
    [SerializeField] GameObject m_fase1Attack1;
    [SerializeField] Fase1Attack1Script m_fase1Attack1Script;
    [SerializeField] SpawnBalls m_spawnBallsScript;
    [SerializeField] SpawnBalls m_spawnBallsScriptPhaze2;
    [SerializeField] GameObject m_fase1Attack2;
    [SerializeField] GameObject m_fase1Attack3;
    [SerializeField] GameObject m_fase1Attack4;
    [SerializeField] GameObject m_phaze2Attack1;
    [SerializeField] GameObject m_phaze2Attack2;
    [SerializeField] GameObject m_phaze2Attack3;
    [SerializeField] Phaze2Attack2Script m_phaze2Attack2Script;
    public int m_explosionBallCount;
    [SerializeField] ConeAttack m_coneAttack;
    [SerializeField] int m_assistantCounterMax;
    public int m_assistantCounterCurrent;
    [SerializeField] List<GameObject> m_enemySpawnPointList = new List<GameObject>();
    [SerializeField] List<GameObject> m_enemySpawnPointListPhaze2 = new List<GameObject>();
    [SerializeField] GameObject m_enemyPrefab;
    [SerializeField] GameObject m_molotEnemyPrefab;
    private int randomNumberPhaze1;
    private int randomNumberPhaze2;
    public bool canGenerateAttack = true;
    public bool m_isPhazeTwo = false;
    public float attackDistancePhaze2;
    public GameObject player;
    [SerializeField] BossHpSystem m_bossHpSystem;



    void Awake()
    {
        m_fase1Attack3.SetActive(false);
        m_fase1Attack2.SetActive(false);
        m_fase1Attack1.SetActive(false);
        m_fase1Attack4.SetActive(false);
        m_phaze2Attack1.SetActive(false);
        m_phaze2Attack2.SetActive(false);
        m_phaze2Attack3.SetActive(false);
        SpawnEnemy();
        GenerateRandomAttack();
    }

    async void FirstAttack()
    {
        if(canGenerateAttack == true && m_isPhazeTwo == false)
        {
            await Task.Delay(2000);
            m_fase1Attack1.SetActive(true);
            m_fase1Attack1Script.SetRandomAnim();
            await Task.Delay(15000);
            m_fase1Attack1.SetActive(false);
            GenerateRandomAttack();
        }
        else
        {
            return;
        }
    }

    async void SecondAttack()
    {
        if (canGenerateAttack == true && m_isPhazeTwo == false)
        {
            m_fase1Attack2.SetActive(true);
            await Task.Delay(19500);
            m_fase1Attack2.SetActive(false);
            GenerateRandomAttack();
        }
        else
        {
            return;
        }
        
    }

    async void SecondLaserAttack()
    {
        if(canGenerateAttack == true && m_isPhazeTwo == false)
        {
            m_fase1Attack4.SetActive(true);
            await Task.Delay(11000);
            m_fase1Attack4.SetActive(false);
            GenerateRandomAttack();
        }
        else
        {
            return;
        }
    }

    async void EndAttack()
    {
        if(canGenerateAttack == true && m_isPhazeTwo == false)
        {
            await Task.Delay(2000);
            m_fase1Attack3.SetActive(true);
            m_spawnBallsScript.SpawnBall();
        }
        else
        {
            return;
        }
    }

    async void SpawnEnemy()
    {
        if (!m_isPhazeTwo)
        {
            await Task.Delay(20000);
            canGenerateAttack = false;
            m_fase1Attack3.SetActive(false);
            m_fase1Attack2.SetActive(false);
            m_fase1Attack1.SetActive(false);
            m_fase1Attack4.SetActive(false);
            foreach (GameObject point in m_enemySpawnPointList)
            {
                Instantiate(m_enemyPrefab, point.transform.position, m_enemyPrefab.transform.rotation);
            }
        }
    }

    async void Attack1Phaze2()
    {
        if (canGenerateAttack && m_isPhazeTwo)
        {
            await Task.Delay(2000);
            m_phaze2Attack1.SetActive(true);
            m_spawnBallsScriptPhaze2.SpawnBall();
        }
        else
        {
            return;
        }
    }

    async void Attack2Phaze2()
    {
        if (canGenerateAttack && m_isPhazeTwo)
        {
            await Task.Delay(2000);
            m_bossAnim.SetBool("Phaze2Attack2", true);
            m_phaze2Attack2.SetActive(true);
            m_phaze2Attack2Script.SetRandomAnim();
            await Task.Delay(5000);
            m_phaze2Attack2.SetActive(false);
            m_bossAnim.SetBool("Phaze2Attack2", false);
            await Task.Delay(4200);
            GenerateRandomAttackPhaze2();
        }
        else
        {
            return;
        }
    }

    async void Attack3Phaze2()
    {
        if (canGenerateAttack && m_isPhazeTwo)
        {
            await Task.Delay(2000);
            m_bossAnim.SetBool("Phaze2Attack3", true);
            m_phaze2Attack3.SetActive(true);
            await Task.Delay(9000);
            m_phaze2Attack3.SetActive(false);
            m_bossAnim.SetBool("Phaze2Attack3", false);
            await Task.Delay(3000);
            GenerateRandomAttackPhaze2();
        }
        else
        {
            return;
        }
    }

    async void Attack4Phaze2()
    {
        if (canGenerateAttack == true && m_isPhazeTwo == true)
        {
            await Task.Delay(2000);
            m_bossAnim.SetBool("Phaze2Attack4", true);
            await Task.Delay(6000);
            m_bossAnim.SetBool("Phaze2Attack4", false);
            await Task.Delay(6000);
            GenerateRandomAttackPhaze2();
        }
        else
        {
            return;
        }
    }

    async public void SpawnEnemyPhase2()
    {
        if (m_isPhazeTwo == true)
        {
            await Task.Delay(120000);
            canGenerateAttack = false;
            m_fase1Attack3.SetActive(false);
            m_fase1Attack2.SetActive(false);
            m_fase1Attack1.SetActive(false);
            m_fase1Attack4.SetActive(false);
            foreach (GameObject point in m_enemySpawnPointListPhaze2)
            {
                Instantiate(m_molotEnemyPrefab, point.transform.position, m_molotEnemyPrefab.transform.rotation);
            }
        }
    }

    void GenerateRandomAttack()
    {
        if(m_isPhazeTwo == false)
        {
            randomNumberPhaze1 = Random.Range(0, 4);
            if (randomNumberPhaze1 == 0)
            {
                FirstAttack();
            }
            if (randomNumberPhaze1 == 1)
            {
                SecondAttack();
            }
            if (randomNumberPhaze1 == 2)
            {
                EndAttack();
            }
            if (randomNumberPhaze1 == 3)
            {
                SecondLaserAttack();
            }
        }
    }

    void GenerateRandomAttackPhaze2()
    {
        if (m_isPhazeTwo == true)
        {
            randomNumberPhaze2 = Random.Range(0, 4);
            if (randomNumberPhaze2 == 0)
            {
                Attack1Phaze2();
            }
            if (randomNumberPhaze2 == 1)
            {
                Attack2Phaze2();
            }
            if (randomNumberPhaze2 == 2)
            {
                Attack3Phaze2();
            }
            if (randomNumberPhaze2 == 3)
            {
                Attack4Phaze2();
            }
        }
    }

    IEnumerator CanTakeDamage()
    {
        m_fase1Attack3.SetActive(false);
        m_fase1Attack2.SetActive(false);
        m_fase1Attack1.SetActive(false);
        m_fase1Attack4.SetActive(false);
        m_bossHpSystem.m_isGetDamage = true;
        m_bossAnim.SetBool("CanTakeDamage", true);
        yield return new WaitForSeconds(15f);
        m_bossAnim.SetBool("CanTakeDamage", false);
        m_bossHpSystem.m_isGetDamage = false;
        m_assistantCounterCurrent = 0;
        canGenerateAttack = true;
        SpawnEnemy();
        GenerateRandomAttack();
        StopAllCoroutines();
    }
    IEnumerator CanTakeDamagePhase2()
    {
        m_fase1Attack3.SetActive(false);
        m_fase1Attack2.SetActive(false);
        m_fase1Attack1.SetActive(false);
        m_fase1Attack4.SetActive(false);
        m_bossHpSystem.m_isGetDamage = true;
        m_bossAnim.SetBool("CanTakeDamagePhase2", true);
        yield return new WaitForSeconds(15f);
        m_bossAnim.SetBool("CanTakeDamagePhase2", false);
        m_bossHpSystem.m_isGetDamage = false;
        m_assistantCounterCurrent = 0;
        canGenerateAttack = true;
        StopAllCoroutines();
    }

    private void Update()
    {
        if(m_coneAttack.m_ballCounter == 5 && m_isPhazeTwo == false)
        {
            m_fase1Attack3.SetActive(false);
            m_coneAttack.m_ballCounter = 0;
            GenerateRandomAttack();
        }
        if(m_assistantCounterCurrent >= m_assistantCounterMax && m_isPhazeTwo == false)
        {
            StartCoroutine(CanTakeDamage());
        }

        if (m_explosionBallCount == 5 && m_isPhazeTwo == true)
        {
            m_phaze2Attack1.SetActive(false);
            m_explosionBallCount = 0;
            GenerateRandomAttackPhaze2();
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistancePhaze2 && m_isPhazeTwo == true)
        {
            m_bossAnim.SetBool("Stomb", true);
        }
        else
        {
            m_bossAnim.SetBool("Stomb", false);
        }
    }
}
