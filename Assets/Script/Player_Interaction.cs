using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    public static Player_Interaction instance;

    public bool isTest;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(isTest)
            {
                isTest = false;
                StartCoroutine(UI_AnimationManager.instance.Move_QuestBoardUI());
            }
            else if(!isTest)
            {
                isTest = true;
                StartCoroutine(UI_AnimationManager.instance.Move_QuestBoardUI());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(collision.CompareTag("Quest_Board"))
            {
                isTest = true;
                StartCoroutine(UI_AnimationManager.instance.Move_QuestBoardUI());
            }
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Quest_Board"))
    //    {
    //        isTest = false;
    //        StartCoroutine(UI_AnimationManager.instance.Move_QuestBoardUI());
    //    }
    //}
}
