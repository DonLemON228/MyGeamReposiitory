using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BossPhaze2AttackScript : MonoBehaviour
{
    [SerializeField] Animator m_bossAnim;
    [SerializeField] GameObject m_phaze2Attack1;
    [SerializeField] GameObject m_phaze2Attack2;
    [SerializeField] GameObject m_phaze2Attack3;
    [SerializeField] Phaze2Attack2Script m_phaze2Attack2Script;
    [SerializeField] List<GameObject> m_enemySpawnPointListPhaze2 = new List<GameObject>();
    [SerializeField] GameObject m_molotEnemyPrefab;
    [SerializeField] BossHpSystem m_bossHpSystem;
    [SerializeField] BossGenerateAttackScript m_bossGenerateAttackScript;
    [SerializeField] BossPhaze1AttackScript m_bossPhaze1Attack;
    [SerializeField] SpawnBalls m_spawnBallsScriptPhaze2;
    public int m_explosionBallCount;
    public float attackDistancePhaze2;
    public int m_assistantCounterCurrent;
    public GameObject player;

    async public void Attack1Phaze2()
    {
        if (m_bossGenerateAttackScript.canGenerateAttack && m_bossGenerateAttackScript.m_isPhazeTwo)
        {
            Debug.Log($"Attack-1-starting {m_bossGenerateAttackScript.m_isPhazeTwo}");
            await Task.Delay(2000);
            Debug.Log($"Attack-2-m_Phaze2Attack2-SetActive - true");
            m_phaze2Attack1.SetActive(true);
            m_spawnBallsScriptPhaze2.SpawnBall();
        }
    }

    async public void Attack2Phaze2()
    {
        if (m_bossGenerateAttackScript.canGenerateAttack && m_bossGenerateAttackScript.m_isPhazeTwo)
        {
            Debug.Log($"Attack-2-starting {m_bossGenerateAttackScript.m_isPhazeTwo}");
            await Task.Delay(2000);
            Debug.Log($"Attack-2-set-bool-Phaze2Attack2 - true");
            m_bossAnim.SetBool("Phaze2Attack2", true);
            Debug.Log($"Attack-2-m_Phaze2Attack2-SetActive - true");
            await Task.Delay(4200);
            m_phaze2Attack2.SetActive(true);
            m_phaze2Attack2Script.SetRandomAnim();
            await Task.Delay(5000);
            m_phaze2Attack2.SetActive(false);
            m_bossAnim.SetBool("Phaze2Attack2", false);
            await Task.Delay(4200);
            Debug.Log($"Attack-2-END");
            m_bossGenerateAttackScript.GenerateRandomAttack();
        }
    }
    async public void Attack3Phaze2()
    {
        if (m_bossGenerateAttackScript.canGenerateAttack && m_bossGenerateAttackScript.m_isPhazeTwo)
        {
            Debug.Log($"Attack-3-starting {m_bossGenerateAttackScript.m_isPhazeTwo}");
            await Task.Delay(2000);
            Debug.Log($"Attack-3-set-bool-Phaze2Attack3 - true");
            m_bossAnim.SetBool("Phaze2Attack3", true);
            await Task.Delay(3000);
            Debug.Log($"Attack-3-m_Phaze2Attack3-SetActive - true");
            m_phaze2Attack3.SetActive(true);
            await Task.Delay(9000);
            m_phaze2Attack3.SetActive(false);
            m_bossAnim.SetBool("Phaze2Attack3", false);
            await Task.Delay(3000);
            Debug.Log($"Attack-3-END");
            m_bossGenerateAttackScript.GenerateRandomAttack();
        }
    }
    async public void Attack4Phaze2()
    {
        if (m_bossGenerateAttackScript.canGenerateAttack && m_bossGenerateAttackScript.m_isPhazeTwo)
        {
            Debug.Log($"Attack-4-starting {m_bossGenerateAttackScript.m_isPhazeTwo}");
            await Task.Delay(2000);
            Debug.Log($"Attack-4-set-bool-Phaze2Attack3 - true");
            m_bossAnim.SetBool("Phaze2Attack4", true);
            Debug.Log($"Attack-4-m_Phaze2Attack4-SetActive - true");
            await Task.Delay(6000);
            m_bossAnim.SetBool("Phaze2Attack4", false);
            await Task.Delay(6000);
            Debug.Log($"Attack-4-END");
            m_bossGenerateAttackScript.GenerateRandomAttack();
        }
    }
    async public void SpawnEnemyPhase2()
    {
        if (m_bossGenerateAttackScript.m_isPhazeTwo)
        {
            await Task.Delay(120000);
            m_bossGenerateAttackScript.canGenerateAttack = false;
            m_phaze2Attack3.SetActive(false);
            m_phaze2Attack2.SetActive(false);
            m_phaze2Attack1.SetActive(false);
            foreach (GameObject point in m_enemySpawnPointListPhaze2)
            {
                Instantiate(m_molotEnemyPrefab, point.transform.position, m_molotEnemyPrefab.transform.rotation);
            }
        }
    }

    IEnumerator CanTakeDamagePhase2()
    {
        m_phaze2Attack1.SetActive(false);
        m_phaze2Attack2.SetActive(false);
        m_phaze2Attack3.SetActive(false);
        m_bossHpSystem.m_isGetDamage = true;
        m_bossAnim.SetBool("CanTakeDamagePhase2", true);
        yield return new WaitForSeconds(15f);
        m_bossAnim.SetBool("CanTakeDamagePhase2", false);
        m_bossHpSystem.m_isGetDamage = false;
        m_assistantCounterCurrent = 0;
        m_bossGenerateAttackScript.canGenerateAttack = true;
        StopAllCoroutines();
    }
    private void Update()
    {
        if (m_explosionBallCount >= 5 && m_bossGenerateAttackScript.m_isPhazeTwo == true)
        {
            m_phaze2Attack1.SetActive(false);
            m_explosionBallCount = 0;
            Debug.Log($"Attack-4-END");
            m_bossGenerateAttackScript.GenerateRandomAttack();
        }
        /*if (Vector3.Distance(transform.position, player.transform.position) <= attackDistancePhaze2 && m_bossGenerateAttackScript.m_isPhazeTwo == true)
        {
            m_bossAnim.SetBool("Stomb", true);
        }
        else
        {
            m_bossAnim.SetBool("Stomb", false);
        }*/
    }
}
