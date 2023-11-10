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

    public Text Quest_NameText;
    public Text Quest_Ex_Text; //퀘스트 내용
    public Image[] QuestItem; //배달에 필요한 아이템
    public int Quest_Cost_Coin; //지불 해야 할 비용
    //public int Overlap_Quest_Coin; //중첩된 퀘스트 골드 : 퀘스트 거절시 돌려줘야 할 골드 양
    public int Accept_Quest_Number; //수락한 퀘스트 개수 
    public Text Accept_Quest_Number_Text; //수락한 퀘스트 개수 텍스트

    //public Sprite[] Quest_Item; //0 빨간 물약 1활 2방망이

    public bool isQuestion;
    public int GiveItemCount;

    private string QuestName;
    private string QuestEx;
    public List<string> Quest_Name = new List<string>();
    public List<string> Quest_Ex = new List<string>();
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
                Quest_Cost_Coin = 300;
                QuestName = "퀘스트A 500골드\n";
                //Quest_NameText.text = "\n퀘스트A 500골드\n";
                //QuestEx = "A아이템을 C지역에서 B지역까지\n배달을 하여라\n\n퀘스트 비용 : 300골드";
                QuestEx = "A아이템을 C지역에서 B지역까지\n배달을 하여라\n\n퀘스트 비용 : 300골드";
                Quest_NameText.text = QuestName;
                Quest_Ex_Text.text = QuestEx;
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            isQuest_Number[0] = true;
            for (int i = 0; i < 5; i++)
            {
                QuestItem[i].sprite = null;
                QuestItem[i].color = new Color(1, 1, 1, 0);
            }
            QuestItem[0].sprite = Inventory.Instance.Red_PotionSprite;
            QuestItem[1].sprite = Inventory.Instance.Red_PotionSprite;
            QuestItem[0].color = new Color(1, 1, 1, 1);
            QuestItem[1].color = new Color(1, 1, 1, 1);
            GiveItemCount = 2;
        }
    }
    public void Quest1()
    {
        if (!isQuest_Number[1] && !isQuestion)
        {
            if (QuestIndex[1] == 0)
            {
                Quest_Cost_Coin = 400;
                //Quest_NameText.text = "\n퀘스트B 600골드\n";
                //Quest_Ex_Text.text = "C아이템을 C지역에서 A지역까지\n배달을 하여라\n\n퀘스트 비용 : 400골드";
                QuestName = "퀘스트B 600골드\n";
                QuestEx = "C아이템을 C지역에서 A지역까지\n배달을 하여라\n\n퀘스트 비용 : 400골드";
                Quest_NameText.text = QuestName;
                Quest_Ex_Text.text = QuestEx;
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            for (int i = 0; i < 5; i++)
            {
                QuestItem[i].sprite = null;
                QuestItem[i].color = new Color(1, 1, 1, 0);
            }
            isQuest_Number[1] = true;
            QuestItem[0].sprite = Inventory.Instance.BowSprite;
            QuestItem[0].color = new Color(1, 1, 1, 1);
            GiveItemCount = 1;
        }
    }
    public void Quest2()
    {
        if (!isQuest_Number[2] && !isQuestion)
        {
            if (QuestIndex[2] == 0)
            {
                Quest_Cost_Coin = 100;
                QuestName = "퀘스트C 400골드\n";
                QuestEx = "A아이템을 C지역에서 B지역까지\n배달을 하여라\n\n퀘스트 비용 : 100골드"; 
                Quest_NameText.text = QuestName;
                Quest_Ex_Text.text = QuestEx;
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            for (int i = 0; i < 5; i++)
            {
                QuestItem[i].sprite = null;
                QuestItem[i].color = new Color(1, 1, 1, 0);
            }
            isQuest_Number[2] = true;
            QuestItem[0].sprite = Inventory.Instance.BatSprite;
            QuestItem[0].color = new Color(1, 1, 1, 1);
            GiveItemCount = 1;
        }
    }
    public void Quest3()
    {
        if (!isQuest_Number[3] && !isQuestion)
        {
            if (QuestIndex[3] == 0)
            {
                Quest_Cost_Coin = 200;
                QuestName = "퀘스트D 600골드\n";
                QuestEx = "B아이템을 A지역에서 B지역까지\n배달을 하여라\n\n퀘스트 비용 : 200골드"; 
                Quest_NameText.text = QuestName;
                Quest_Ex_Text.text = QuestEx;
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            for (int i = 0; i < 5; i++)
            {
                QuestItem[i].sprite = null;
                QuestItem[i].color = new Color(1, 1, 1, 0);
            }
            isQuest_Number[3] = true;
            QuestItem[0].sprite = Inventory.Instance.Red_PotionSprite;
            QuestItem[0].color = new Color(1, 1, 1, 1);
            GiveItemCount = 1;
        }
    }
    public void Quest4()
    {
        if (!isQuest_Number[4] && !isQuestion)
        {
            if (QuestIndex[4] == 0)
            {
                Quest_Cost_Coin = 400;
                QuestName = "퀘스트E 600골드\n";
                QuestEx = "A아이템을 C지역에서 B지역까지\n배달을 하여라\n\n퀘스트 비용 : 400골드";
                Quest_NameText.text = QuestName;
                Quest_Ex_Text.text = QuestEx;
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            for (int i = 0; i < 5; i++)
            {
                QuestItem[i].sprite = null;
                QuestItem[i].color = new Color(1, 1, 1, 0);
            }
            isQuest_Number[4] = true;
            QuestItem[0].sprite = Inventory.Instance.BowSprite;
            QuestItem[0].color = new Color(1, 1, 1, 1);
            GiveItemCount = 1;
        }
    }
    public void Quest5()
    {
        if (!isQuest_Number[5] && !isQuestion)
        {
            if (QuestIndex[5] == 0)
            {
                Quest_Cost_Coin = 500;
                QuestName = "퀘스트F 800골드\n";
                QuestEx = "C아이템을 B지역에서 A지역까지\n배달을 하여라\n\n퀘스트 비용 : 500골드";
                Quest_NameText.text = QuestName;
                Quest_Ex_Text.text = QuestEx;
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            for (int i = 0; i < 5; i++)
            {
                QuestItem[i].sprite = null;
                QuestItem[i].color = new Color(1, 1, 1, 0);
            }
            isQuest_Number[5] = true;
            QuestItem[0].sprite = Inventory.Instance.Red_PotionSprite;
            QuestItem[0].color = new Color(1, 1, 1, 1);
            GiveItemCount = 1;
        }
    }
    public void Quest6()
    {
        if (!isQuest_Number[6] && !isQuestion)
        {
            if (QuestIndex[6] == 0)
            {
                Quest_Cost_Coin += 210;
                QuestName = "퀘스트G 600골드\n";
                QuestEx = "A아이템을 A지역에서 B지역까지\n배달을 하여라\n\n퀘스트 비용 : 210골드";
                Quest_NameText.text = QuestName;
                Quest_Ex_Text.text = QuestEx;
            }
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                isQuest_Number[i] = false;
            }
            for (int i = 0; i < 5; i++)
            {
                QuestItem[i].sprite = null;
                QuestItem[i].color = new Color(1, 1, 1, 0);
            }
            isQuest_Number[6] = true;
            QuestItem[0].sprite = Inventory.Instance.BatSprite;
            QuestItem[0].color = new Color(1, 1, 1, 1);
            GiveItemCount = 1;
        }
    }
    private void Update()
    {
        Accept_Quest_Number_Text.text = "수락한 퀘스트 개수 : " + Accept_Quest_Number + "개";

        if(isMap && Input.GetKeyDown(KeyCode.Escape))
        {
            isMap = false;
            StartCoroutine(UI_AnimationManager.instance.Move_MapUI());
        }
    }
    public Image Quest_Re_questionIMG;
    public void Quest_Question()
    {
        Quest_Re_questionIMG.gameObject.SetActive(true);
        isQuestion = true;
    }
    public bool isMap;
    public void MapBtn()
    {
        if(!isMap)
        {
            isMap = true;
        }
        else
        {
            isMap = false;
        }
        StartCoroutine(UI_AnimationManager.instance.Move_MapUI());
    }
    public Image StartBtn;
    public Sprite[] StartBtnSprite;
    public void MapStart_Btn()
    {
       StartCoroutine(MapStartBtnAni());
    }
    IEnumerator MapStartBtnAni()
    {
        StartBtn.sprite = StartBtnSprite[1];
        yield return new WaitForSeconds(0.2f);
        StartBtn.sprite = StartBtnSprite[0];
        if(isMapPin)
        {
            LoadingScene.LoadScene("DragonLine");
        }
    }
    public void Close_Quest_Question()
    {
        Quest_Re_questionIMG.gameObject.SetActive(false);
        isQuestion = false;
    }
    public void Quest_Accept()
    {
        isQuestion = false;
        int NullSlotCount = 0;
        for (int i = 0; i < Inventory.Instance.Inventory_Slot.Count; i++)
        {
            if (Inventory.Instance.Inventory_Slot[i].transform.childCount == 0)
            {
                NullSlotCount++;
            }
        }
        if(NullSlotCount >= GiveItemCount)
        {
            for (int i = 0; i < isQuest_Number.Length; i++)
            {
                if (isQuest_Number[i] && !isQuest_Accept[i] && Player.Instance.Gold >= Quest_Cost_Coin)
                {
                    isQuest_Accept[i] = true;
                    Set_Item();
                    Player.Instance.Gold -= Quest_Cost_Coin;
                    QuestIndex[i]++;
                    Accept_Quest_Number++;
                    isQuest_Number[i] = false;
                    Quest_Cost_Coin = 0;
                    Quest_Name.Add(QuestName);
                    Quest_Ex.Add(QuestEx);
                    Debug.Log("퀘스트 수락");
                    //Overlap_Quest_Coin += Quest_Cost_Coin;
                }
            }
        }
        Quest_Re_questionIMG.gameObject.SetActive(false);
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

    public Image MapPin;
    public bool isMapPin;
    public Sprite MapPinSprite;
    public void MapPinBtn() //드래곤 시티 위치 버튼 - MapBtn
    {
        if(!isMapPin)
        {
            isMapPin = true;
            MapPin.sprite = MapPinSprite;
            MapPin.color = new Color(1, 1, 1, 1);
        }
        else if (isMapPin)
        {
            isMapPin = false;
            MapPin.color = new Color(1, 1, 1, 0);
            MapPin.sprite = null;
        }
    }
}
