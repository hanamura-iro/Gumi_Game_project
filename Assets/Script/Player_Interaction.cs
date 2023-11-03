using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    public static Player_Interaction instance;

    public bool isQuestBoard;
    public bool isQuestBoardCollider;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(isQuestBoard && isQuestBoardCollider)
            {
                StartCoroutine(UI_AnimationManager.instance.Move_QuestBoardUI());
                isQuestBoard = false;
            }
            else if (!isQuestBoard && isQuestBoardCollider)
            {
                isQuestBoard = true;
                StartCoroutine(UI_AnimationManager.instance.Move_QuestBoardUI());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Quest_Board"))
        {
            isQuestBoardCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Quest_Board"))
        {
            if(isQuestBoard)
            {
                isQuestBoardCollider = false;
                isQuestBoard = false;
                StartCoroutine(UI_AnimationManager.instance.Move_QuestBoardUI());
            }
        }
    }
}
