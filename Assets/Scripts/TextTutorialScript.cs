using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextTutorialScript : MonoBehaviour
{
    [SerializeField] HpSystem m_player;
    [SerializeField] BoxCollider m_colliderObject;
    [SerializeField] string[] m_lines;
    [SerializeField] float m_speedText;
    [SerializeField] Text m_dialogText;
    [SerializeField] int m_index;
    [SerializeField] bool m_isTeleporMenu;

    private void Start()
    {
        m_dialogText.text = string.Empty;
        StartText();
        m_player.BlockMove();
    }

    void StartText()
    {
        m_index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in m_lines[m_index].ToCharArray())
        {
            m_dialogText.text += c;
            yield return new WaitForSeconds(m_speedText);
        }
    }

    void TextClic()
    {
        if(m_dialogText.text == m_lines[m_index])
        {
            NewLines();
        }
        else
        {
            StopAllCoroutines();
            m_dialogText.text = m_lines[m_index];
        }
    }

    void NewLines()
    {
        if (m_index < m_lines.Length - 1)
        {
            m_index++;
            m_dialogText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Destroy(m_colliderObject);
            gameObject.SetActive(false);
            m_player.UnblockMove();
            if(m_isTeleporMenu)
                SceneManager.LoadScene("Menu");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TextClic();

        if(Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }
}
