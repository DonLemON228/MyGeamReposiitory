using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class RoomTeleportScript : MonoBehaviour
{
    [SerializeField] Transform m_portal;
    [SerializeField] AudioSource m_tpSound;
    [SerializeField] AudioSource m_idleSound;

    private async void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            other.GetComponent<Animator>().SetTrigger("Teleport");
            var playerMove = other.GetComponent<HpSystem>();
            playerMove.BlockMove();
            m_idleSound.Stop();
            m_tpSound.Play();
            await Task.Delay(300);
            other.transform.position = m_portal.position;
            playerMove.UnblockMove();
        }
    }
}
