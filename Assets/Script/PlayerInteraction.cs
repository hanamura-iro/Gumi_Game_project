using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Image Quest_board;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Quest_board") && Input.GetKeyDown(KeyCode.E))
        {
            Quest_board.gameObject.SetActive(true);
            Debug.Log("¥Í¿”");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Quest_board"))
        {
            Quest_board.gameObject.SetActive(false);
        }
    }
}
