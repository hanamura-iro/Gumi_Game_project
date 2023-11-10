using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    public static Player_Interaction instance;
    public Camera Camera;
    public bool isQuestBoard;
    public bool isInHouse;

    public GameObject isHouseRoom;
    public GameObject Map1;
    public GameObject Map2;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(isQuestBoardCollider)
            {
                if(isQuestBoard)
                {
                    StartCoroutine(UI_AnimationManager.instance.Move_QuestBoardUI());
                    isQuestBoard = false;
                    if(QuestManager.Instance.isMap)
                    {
                        QuestManager.Instance.isMap = false;
                        StartCoroutine(UI_AnimationManager.instance.Move_MapUI());
                    }
                }
                else if (!isQuestBoard)
                {
                    isQuestBoard = true;
                    StartCoroutine(UI_AnimationManager.instance.Move_QuestBoardUI());
                }
            }

            else if(isHouseDoorCollider && !isInHouse)
            {
                Map2.SetActive(false);
                isHouseRoom.SetActive(true);
                Player.Instance.transform.position = new Vector3(2.3f, 2.6f, 0);
                Camera.transform.position = new Vector3(2, 4.2f, -8);
                isInHouse = true;
            }
            else if(isInHouse && isHouseDoorCollider && Tutorial.Instance.TutorialItems[0] == null && Tutorial.Instance.TutorialItems[1] == null)
            {
                isHouseRoom.SetActive(false);
                Map2.SetActive(true);
                Player.Instance.transform.position = new Vector3(-14.5f, 1.6f, 0);
                Camera.transform.position = new Vector3(-14, 4.2f, -8);
                isInHouse = false;
                Tutorial.Instance.NextText();
            }
            else if(isinjured_personCollider)
            {
                if(Tutorial.Instance.TextIndex == 8 || Tutorial.Instance.TextIndex == 15)
                    Tutorial.Instance.NextText();
            }
        }
    }
    public bool isQuestBoardCollider;
    public bool isHouseDoorCollider;
    public bool isinjured_personCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Quest_Board"))
        {
            isQuestBoardCollider = true;
        }
        else if(collision.CompareTag("HouseDoor"))
        {
            isHouseDoorCollider = true;
        }
        else if(collision.CompareTag("injured_person"))
        {
            isinjured_personCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Quest_Board"))
        {
            isQuestBoardCollider = false;
            if(isQuestBoard)
            {
                isQuestBoard = false;
                StartCoroutine(UI_AnimationManager.instance.Move_QuestBoardUI());
                if(QuestManager.Instance.isMap)
                {
                    QuestManager.Instance.isMap = false;
                    StartCoroutine(UI_AnimationManager.instance.Move_MapUI());
                }
            }
        }
        else if(collision.CompareTag("HouseDoor"))
        {
            isHouseDoorCollider = false;
        }
        else if (collision.CompareTag("injured_person"))
        {
            isinjured_personCollider = false;
        }
    }
}
