using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [Header("퀘스트 번호")] public int[] QuestIndex; //퀘스트 번호
    [Header("선택한 퀘스트")] public bool[] isQuest_Number; //선택한 퀘스트 번호 
    [Header("수락된 퀘스트")] public bool[] isQuest_Accept; //수락한 퀘스트 번호

    public Text Quest_Ex_Text; //퀘스트 내용
    public Image QuestItem; //배달에 필요한 아이템
    public int Quest_Cost_Coin; //지불 해야 할 비용
    //public int Overlap_Quest_Coin; //중첩된 퀘스트 골드 : 퀘스트 거절시 돌려줘야 할 골드 양
    public int Accept_Quest_Number; //수락한 퀘스트 개수 
    public Text Accept_Quest_Number_Text; //수락한 퀘스트 개수 텍스트

    public Sprite[] Quest_Item; //0 빨간 물약 1활 2방망이

    public bool isQuestion;
    private void Awake()
    {
        Instance = this;
    }
    public void Quest0()
    {
        if (!isQuest_Number[0] && !isQuestion)
        {
            if (QuestIndex[0] == 0)
            {
                QuestItem.sprite = Quest_Item[0];
                Quest_Cost_Coin = 300;
                Quest_Ex_Text.text = "퀘스트 0\n\nA아이템을 C지역에서 B지역까지 배달을 하여라\n\n퀘스트 비용 : 300골드\n\n퀘스트 보상 : 500 골드";
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            isQuest_Number[0] = true;
            QuestItem.color = new Color(1, 1, 1, 1);
        }
    }
    public void Quest1()
    {
        if (!isQuest_Number[1] && !isQuestion)
        {
            if (QuestIndex[1] == 0)
            {
                QuestItem.sprite = Quest_Item[1];
                Quest_Cost_Coin = 400;
                Quest_Ex_Text.text = "퀘스트 1\n\nC아이템을 C지역에서 A지역까지 배달을 하여라\n\n퀘스트 비용 : 400골드\n\n퀘스트 보상 : 600 골드";
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            isQuest_Number[1] = true;
            QuestItem.color = new Color(1, 1, 1, 1);
        }
    }
    public void Quest2()
    {
        if (!isQuest_Number[2] && !isQuestion)
        {
            if (QuestIndex[2] == 0)
            {
                QuestItem.sprite = Quest_Item[2];
                Quest_Cost_Coin = 100;
                Quest_Ex_Text.text = "퀘스트 2\n\nA아이템을 C지역에서 B지역까지 배달을 하여라\n\n퀘스트 비용 : 100골드\n\n퀘스트 보상 : 400 골드";
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            isQuest_Number[2] = true;
            QuestItem.color = new Color(1, 1, 1, 1);
        }
    }
    public void Quest3()
    {
        if (!isQuest_Number[3] && !isQuestion)
        {
            if (QuestIndex[3] == 0)
            {
                QuestItem.sprite = Quest_Item[0];
                Quest_Cost_Coin = 200;
                Quest_Ex_Text.text = "퀘스트 3\n\nB아이템을 A지역에서 B지역까지 배달을 하여라\n\n퀘스트 비용 : 200골드\n\n퀘스트 보상 : 600 골드";
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            isQuest_Number[3] = true;
            QuestItem.color = new Color(1, 1, 1, 1);
        }
    }
    public void Quest4()
    {
        if (!isQuest_Number[4] && !isQuestion)
        {
            if (QuestIndex[4] == 0)
            {
                QuestItem.sprite = Quest_Item[1];
                Quest_Cost_Coin = 400;
                Quest_Ex_Text.text = "퀘스트 4\n\nA아이템을 C지역에서 B지역까지 배달을 하여라\n\n퀘스트 비용 : 400골드\n\n퀘스트 보상 : 600 골드";
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            isQuest_Number[4] = true;
            QuestItem.color = new Color(1, 1, 1, 1);
        }
    }
    public void Quest5()
    {
        if (!isQuest_Number[5] && !isQuestion)
        {
            if (QuestIndex[5] == 0)
            {
                QuestItem.sprite = Quest_Item[0];
                Quest_Cost_Coin = 500;
                Quest_Ex_Text.text = "퀘스트 5\n\nC아이템을 B지역에서 A지역까지 배달을 하여라\n\n퀘스트 비용 : 500골드\n\n퀘스트 보상 : 800 골드";
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            isQuest_Number[5] = true;
            QuestItem.color = new Color(1, 1, 1, 1);
        }
    }
    public void Quest6()
    {
        if (!isQuest_Number[6] && !isQuestion)
        {
            if (QuestIndex[6] == 0)
            {
                QuestItem.sprite = Quest_Item[2];
                Quest_Cost_Coin += 210;
                Quest_Ex_Text.text = "퀘스트6\n\nA아이템을 A지역에서 B지역까지 배달을 하여라\n\n퀘스트 비용 : 210골드\n\n퀘스트 보상 : 600 골드";
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            isQuest_Number[6] = true;
            QuestItem.color = new Color(1, 1, 1, 1);
        }
    }
    private void Update()
    {
        Accept_Quest_Number_Text.text = "수락한 퀘스트 개수 : " + Accept_Quest_Number + "개";
    }
    public Image Quest_Re_questionIMG;
    public void Quest_Question()
    {
        Quest_Re_questionIMG.gameObject.SetActive(true);
        isQuestion = true;
    }
    public void Close_Quest_Question()
    {
        Quest_Re_questionIMG.gameObject.SetActive(false);
        isQuestion = false;
    }
    public void Quest_Accept()
    {
        isQuestion = false;
        for (int i = 0; i < isQuest_Number.Length; i++)
        {
            if (isQuest_Number[i] && !isQuest_Accept[i] && GameManager.Instance.Gold >= Quest_Cost_Coin)
            {
                isQuest_Accept[i] = true;
                Set_Item();
                GameManager.Instance.Gold -= Quest_Cost_Coin;
                QuestIndex[i]++;
                Accept_Quest_Number++;
                isQuest_Number[i] = false;
                Quest_Cost_Coin = 0;
                //Overlap_Quest_Coin += Quest_Cost_Coin;
            }
        }
        Quest_Re_questionIMG.gameObject.SetActive(false);
    }
    //public void Reject_Quest()
    //{
    //    QuestItem.color = new Color(1, 1, 1, 0);
    //    Quest_Cost_Coin = 0;
    //    QuestItem.sprite = null;
    //    Quest_Ex_Text.text = "";

    //    for (int i = 0; i < isQuest_Number.Length; i++)
    //    {
    //        if (isQuest_Number[i])
    //        {
    //            isQuest_Number[i] = false;
    //        }
    //        if (QuestIndex[i] >= 1 && isQuest_Accept[i])
    //        {
    //            Get_Item(i);
    //            //QuestIndex[i]--;
    //            //isQuest_Accept[i] = false;
    //        }
    //    }
    //    GameManager.Instance.Gold += Overlap_Quest_Coin;
    //    Overlap_Quest_Coin = 0;
    //    Accept_Quest_Number = 0;
    //}
    public void Close_Quest_Board()
    {
        Player_Interaction.instance.isTest = false;
        StartCoroutine(UI_AnimationManager.instance.Move_QuestBoardUI());
        //Quest_Board.SetActive(false);
    }
    public void Set_Item() //퀘스트 아이템 지급
    {
        if (isQuest_Accept[0])
        {
            if (QuestIndex[0] == 0)
            {
                Inventory.Instance.Set_Item(Type.RedPotion);
                Inventory.Instance.Set_Item(Type.RedPotion);
            }
        }
        if (isQuest_Accept[1])
        {
            if (QuestIndex[1] == 0)
            {
                Inventory.Instance.Set_Item(Type.bow);
            }
        }
        if (isQuest_Accept[2])
        {
            if (QuestIndex[2] == 0)
            {
                Inventory.Instance.Set_Item(Type.bat);
            }
        }
        if (isQuest_Accept[3])
        {
            if (QuestIndex[3] == 0)
            {
                Inventory.Instance.Set_Item(Type.RedPotion);
            }
        }
        if (isQuest_Accept[4])
        {
            if (QuestIndex[4] == 0)
            {
                Inventory.Instance.Set_Item(Type.bow);
            }
        }
        if (isQuest_Accept[5])
        {
            if (QuestIndex[5] == 0)
            {
                Inventory.Instance.Set_Item(Type.RedPotion);
            }
        }
        if (isQuest_Number[6])
        {
            if (QuestIndex[6] == 0)
            {
                Inventory.Instance.Set_Item(Type.bat);
            }
        }
    }
    public void Get_Item(int i)
    {
        if (isQuest_Accept[0])
        {
            isQuest_Accept[i] = false;
            if (QuestIndex[0] == 0)
            {
                Destroy(GameObject.Find("Red_potionIMG(Clone)"));
            }
            QuestIndex[i]--;
        }
        if (isQuest_Accept[1])
        {
            isQuest_Accept[i] = false;
            if (QuestIndex[1] == 0)
            {
                Destroy(GameObject.Find("Red_potionIMG(Clone)"));
            }
            QuestIndex[i]--;
        }
        if (isQuest_Accept[2])
        {
            isQuest_Accept[i] = false;
            if (QuestIndex[2] == 0)
            {
                Destroy(GameObject.Find("Red_potionIMG(Clone)"));
            }
            QuestIndex[i]--;
        }
        if (isQuest_Accept[3])
        {
            isQuest_Accept[i] = false;
            if (QuestIndex[3] == 0)
            {
                Destroy(GameObject.Find("Red_potionIMG(Clone)"));
            }
            QuestIndex[i]--;
        }
        if (isQuest_Accept[4])
        {
            isQuest_Accept[i] = false;
            if (QuestIndex[4] == 0)
            {
                Destroy(GameObject.Find("Red_potionIMG(Clone)"));
            }
            QuestIndex[i]--;
        }
        if (isQuest_Accept[5])
        {
            isQuest_Accept[i] = false;
            if (QuestIndex[5] == 0)
            {
                Destroy(GameObject.Find("Red_potionIMG(Clone)"));
            }
            QuestIndex[i]--;
        }
        if (isQuest_Number[6])
        {
            isQuest_Accept[i] = false;
            if (QuestIndex[6] == 0)
            {
                Destroy(GameObject.Find("Red_potionIMG(Clone)"));
            }
            QuestIndex[i]--;
        }

    }
}
