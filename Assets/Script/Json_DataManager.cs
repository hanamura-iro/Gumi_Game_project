using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

[Serializable]
public class Data
{
    public List<string> Equip_Inventory_Item;
    public List<int> Equip_Inventory_SlotIndex = new List<int>();

    public List<string> Inventory_Item = new List<string>();
    public List<int> Inventory_SlotIndex = new List<int>();

    public int PlayerGold;

    public int PlayerHP;
    public int PlayerMaxHP;

    public int PlayerStemina;
    public int PlayerMaxStemina;

    public Vector3 Player_pos;

    public int[] QuestIndex = { 0, 0, 0, 0, 0, 0, 0 }; //퀘스트 인덱스
    public bool[] isQuest_Accept = { false, false, false, false, false, false, false }; //수락 된 퀘스트 
    public int Accept_Quest_Number; //수락한 퀘스트 개수 
}
[Serializable]
public class Json_DataManager : MonoBehaviour
{
    public static Json_DataManager instance;
    public Data data;
    private void Start()
    {
        instance = this;
        LoadDataToJson();
    }
    [ContextMenu("Reset Json Data")]
    public void ResetDataToJson()
    {
        data.Equip_Inventory_Item = new List<string>();
        data.Equip_Inventory_SlotIndex = new List<int>();

        data.Inventory_Item = new List<string>();
        data.Inventory_SlotIndex = new List<int>();

        data.PlayerGold = 6533;

        data.PlayerHP = 3;
        data.PlayerMaxHP = 3;

        data.PlayerStemina = 5;
        data.PlayerMaxStemina = 5;

        data.Player_pos = new Vector3(0,2,0);

        for (int i = 0; i < 7; i++)
        {
            data.QuestIndex[i] = 0;
            data.isQuest_Accept[i] = false;
        }
        data.Accept_Quest_Number = 0;

        SceneManager.LoadScene("InGame");
        //LoadingScene.LoadScene("Game");
        string GameData = JsonUtility.ToJson(data, true);
        string path = Path.Combine(Application.persistentDataPath, "Gamedata.json");
        File.WriteAllText(path, GameData);
    }
    [ContextMenu("To Json Data")]
    public void SaveDataToJson()
    {
        ResetDataToJson();
        for (int i = 0; i < Inventory.Instance.Inventory_Slot.Count; i++)
        {
            if (Inventory.Instance.Inventory_Slot[i].transform.childCount == 1)
            {
                data.Inventory_Item.Add(Inventory.Instance.Inventory_Slot[i].transform.GetChild(0).gameObject.name);
                data.Inventory_SlotIndex.Add(i);
            }
        }
        for (int i = 0; i < Inventory.Instance.Equip_Inventory_Slot.Count; i++)
        {
            if (Inventory.Instance.Equip_Inventory_Slot[i].transform.childCount == 1)
            {
                data.Equip_Inventory_Item.Add(Inventory.Instance.Equip_Inventory_Slot[i].transform.GetChild(0).gameObject.name);
                data.Equip_Inventory_SlotIndex.Add(i);
            }
        }
        data.PlayerGold = Player.Instance.Gold;

        data.PlayerHP = Player.Instance.Hp;
        data.PlayerMaxHP = Player.Instance.MaxHP;

        data.PlayerStemina = Player.Instance.Stemina;
        data.PlayerMaxStemina = Player.Instance.MaxStemina;

        data.Player_pos = Player.Instance.transform.position;

        for (int i = 0; i < 7; i++)
        {
            data.QuestIndex[i] = QuestManager.Instance.QuestIndex[i];
            data.isQuest_Accept[i] = QuestManager.Instance.isQuest_Accept[i];
        }
        data.Accept_Quest_Number = QuestManager.Instance.Accept_Quest_Number;

        string GameData = JsonUtility.ToJson(data, true);
        string path = Path.Combine(Application.persistentDataPath, "Gamedata.json");
        File.WriteAllText(path, GameData);
        PlayerPrefs.Save();
        Debug.Log("저장 완료");
    }

    [ContextMenu("From Json Data")]
    public void LoadDataToJson()
    {
        string path = Path.Combine(Application.persistentDataPath, "Gamedata.json");
        string Data = File.ReadAllText(path);
        data = JsonUtility.FromJson<Data>(Data);
        
        LoadItem();

        Player.Instance.Gold = data.PlayerGold;

        Player.Instance.Hp = data.PlayerHP;
        Player.Instance.MaxHP = data.PlayerMaxHP;

        Player.Instance.Stemina = data.PlayerStemina;
        Player.Instance.MaxStemina = data.PlayerMaxStemina;
        Player.Instance.Player_H_S_UI();

        Player.Instance.transform.position = data.Player_pos;

        for (int i = 0; i < 7; i++)
        {
            QuestManager.Instance.QuestIndex[i] = data.QuestIndex[i];
            QuestManager.Instance.isQuest_Accept[i] = data.isQuest_Accept[i];
        }
        QuestManager.Instance.Accept_Quest_Number = data.Accept_Quest_Number;

        Debug.Log("로드 완료");
    }
    void LoadItem()
    {
        for (int i = 0; i < data.Equip_Inventory_Item.Count; i++)
        {
            Equip_Inventory_Item_Instantiate(i);
        }
        for (int i = 0; i < data.Inventory_Item.Count; i++)
        {
            Inventory_Item_Instantiate(i);
        }
    }
    void Equip_Inventory_Item_Instantiate(int i)
    {
        if (data.Equip_Inventory_Item[i] == Inventory.Instance.Red_PotionIMG.name + "(Clone)")
        {
            Instantiate(Inventory.Instance.Red_PotionIMG, Inventory.Instance.Equip_Inventory_Slot[data.Equip_Inventory_SlotIndex[i]].transform);
        }
        else if (data.Equip_Inventory_Item[i] == Inventory.Instance.BowIMG.name + "(Clone)")
        {
            Instantiate(Inventory.Instance.BowIMG, Inventory.Instance.Equip_Inventory_Slot[data.Equip_Inventory_SlotIndex[i]].transform);
        }
        else if (data.Equip_Inventory_Item[i] == Inventory.Instance.BatIMG.name + "(Clone)")
        {
            Instantiate(Inventory.Instance.BatIMG, Inventory.Instance.Equip_Inventory_Slot[data.Equip_Inventory_SlotIndex[i]].transform);
        }
    }
    void Inventory_Item_Instantiate(int i)
    {
        if (data.Inventory_Item[i] == Inventory.Instance.Red_PotionIMG.name + "(Clone)")
        {
            Instantiate(Inventory.Instance.Red_PotionIMG, Inventory.Instance.Inventory_Slot[data.Inventory_SlotIndex[i]].transform);
        }
        else if (data.Inventory_Item[i] == Inventory.Instance.BowIMG.name + "(Clone)")
        {
            Instantiate(Inventory.Instance.BowIMG, Inventory.Instance.Inventory_Slot[data.Inventory_SlotIndex[i]].transform);
        }
        else if (data.Inventory_Item[i] == Inventory.Instance.BatIMG.name + "(Clone)")
        {
            Instantiate(Inventory.Instance.BatIMG, Inventory.Instance.Inventory_Slot[data.Inventory_SlotIndex[i]].transform);
        }
    }
}
