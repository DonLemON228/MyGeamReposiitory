using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BossPhaze1AttackScript : MonoBehaviour
{
    [SerializeField] Animator m_bossAnim;
    [SerializeField] Fase1Attack1Script m_phaze1Attack1Script;
    [SerializeField] SpawnBalls m_spawnBallsScript;
    [SerializeField] GameObject m_phaze1Attack1;
    [SerializeField] GameObject m_phaze1Attack2;
    [SerializeField] GameObject m_phaze1Attack3;
    [SerializeField] GameObject m_phaze1Attack4;
    [SerializeField] List<GameObject> m_enemySpawnPointList = new List<GameObject>();
    [SerializeField] GameObject m_enemyPrefab;
    [SerializeField] BossHpSystem m_bossHpSystem;
    [SerializeField] ConeAttack m_coneAttack;
    [SerializeField] BossGenerateAttackScript m_bossGenerateAttackScript;
    [SerializeField] int m_assistantCounterMax;
    public int m_assistantCounterCurrent;


    void Awake()
    {
        m_phaze1Attack3.SetActive(false);
        m_phaze1Attack2.SetActive(false);
        m_phaze1Attack1.SetActive(false);
        m_phaze1Attack4.SetActive(false);
        SpawnEnemy();
        m_bossGenerateAttackScript.GenerateRandomAttack();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
    }

    async public void Phaze1Attack1()
    {
        if (m_bossGenerateAttackScript.canGenerateAttack == true && m_bossGenerateAttackScript.m_isPhazeTwo == false)
        {
            await Task.Delay(2000);
            m_phaze1Attack1.SetActive(true);
            m_phaze1Attack1Script.SetRandomAnim();
            await Task.Delay(15000);
            m_phaze1Attack1.SetActive(false);
            m_bossGenerateAttackScript.GenerateRandomAttack();
        }
    }

    async public void Phaze1Attack2()
    {
        if (m_bossGenerateAttackScript.canGenerateAttack == true && m_bossGenerateAttackScript.m_isPhazeTwo == false)
        {
            m_phaze1Attack2.SetActive(true);
            await Task.Delay(19500);
            m_phaze1Attack2.SetActive(false);
            m_bossGenerateAttackScript.GenerateRandomAttack();
        }
    }

    async public void Phaze1Attack3()
    {
        if (m_bossGenerateAttackScript.canGenerateAttack == true && m_bossGenerateAttackScript.m_isPhazeTwo == false)
        {
            m_phaze1Attack4.SetActive(true);
            await Task.Delay(11000);
            m_phaze1Attack4.SetActive(false);
            m_bossGenerateAttackScript.GenerateRandomAttack();
        }
    }

    async public void Phaze1Attack4()
    {
        if (m_bossGenerateAttackScript.canGenerateAttack == true && m_bossGenerateAttackScript.m_isPhazeTwo == false)
        {
            await Task.Delay(2000);
            m_phaze1Attack3.SetActive(true);
            m_spawnBallsScript.SpawnBall();
        }
    }

    async public void SpawnEnemy()
    {
        if (!m_bossGenerateAttackScript.m_isPhazeTwo)
        {
            await Task.Delay(120000);
            m_bossGenerateAttackScript.canGenerateAttack = false;
            m_phaze1Attack1.SetActive(false);
            m_phaze1Attack2.SetActive(false);
            m_phaze1Attack3.SetActive(false);
            m_phaze1Attack4.SetActive(false);
            foreach (GameObject point in m_enemySpawnPointList)
            {
                Instantiate(m_enemyPrefab, point.transform.position, m_enemyPrefab.transform.rotation);
            }
        }
    }

    IEnumerator CanTakeDamage()
    {
        m_phaze1Attack3.SetActive(false);
        m_phaze1Attack2.SetActive(false);
        m_phaze1Attack1.SetActive(false);
        m_phaze1Attack4.SetActive(false);
        m_bossHpSystem.m_isGetDamage = true;
        m_bossAnim.SetBool("CanTakeDamage", true);
        yield return new WaitForSeconds(15f);
        m_bossAnim.SetBool("CanTakeDamage", false);
        m_bossHpSystem.m_isGetDamage = false;
        m_assistantCounterCurrent = 0;
        m_bossGenerateAttackScript.canGenerateAttack = true;
        SpawnEnemy();
        m_bossGenerateAttackScript.GenerateRandomAttack();
        StopAllCoroutines();
    }

    private void Update()
    {
        if (m_coneAttack.m_ballCounter == 5 && m_bossGenerateAttackScript.m_isPhazeTwo == false)
        {
            m_phaze1Attack3.SetActive(false);
            m_coneAttack.m_ballCounter = 0;
            m_bossGenerateAttackScript.GenerateRandomAttack();
        }
        if (m_assistantCounterCurrent >= m_assistantCounterMax && m_bossGenerateAttackScript.m_isPhazeTwo == false)
        {
            StartCoroutine(CanTakeDamage());
        }
    }
}
