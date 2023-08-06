using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerateAttackScript : MonoBehaviour
{
    [SerializeField] BossPhaze1AttackScript m_bossPhaze1Attack;
    [SerializeField] BossPhaze2AttackScript m_bossPhaze2Attack;
    private int randomNumberPhaze1;
    private int randomNumberPhaze2;
    public bool canGenerateAttack = false;
    public bool m_isPhazeTwo = false;


    public void GenerateRandomAttack()
    {
        if(!m_isPhazeTwo)
        {
            randomNumberPhaze1 = Random.Range(0, 4);
            if (randomNumberPhaze1 == 0)
            {
                m_bossPhaze1Attack.Phaze1Attack1();
            }
            if (randomNumberPhaze1 == 1)
            {
                m_bossPhaze1Attack.Phaze1Attack2();
            }
            if (randomNumberPhaze1 == 2)
            {
                m_bossPhaze1Attack.Phaze1Attack3();
            }
            if (randomNumberPhaze1 == 3)
            {
                m_bossPhaze1Attack.Phaze1Attack4();
            }
        }
        else
        {
            randomNumberPhaze2 = Random.Range(0, 4);
            if (randomNumberPhaze2 == 0)
            {
                m_bossPhaze2Attack.Attack1Phaze2();
            }
            if (randomNumberPhaze2 == 1)
            {
                m_bossPhaze2Attack.Attack2Phaze2();
            }
            if (randomNumberPhaze2 == 2)
            {
                m_bossPhaze2Attack.Attack3Phaze2();
            }
            if (randomNumberPhaze2 == 3)
            {
                m_bossPhaze2Attack.Attack4Phaze2();
            }
        }
    }
}
