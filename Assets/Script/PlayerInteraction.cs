using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Image Quest_board;
    public bool isQueest_borad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Quest_board"))
        {
            isQueest_borad = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Quest_board"))
        {
            isQueest_borad = false;
            Quest_board.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        GetInteraction();
    }
    public void GetInteraction() //오브젝트 상호작용 (퀘스트 보드 등등)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isQueest_borad)
            {
                Quest_board.gameObject.SetActive(true);
            }
        }
    }
}
