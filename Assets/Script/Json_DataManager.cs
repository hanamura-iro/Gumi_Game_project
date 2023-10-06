using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class Data
{
    public List<string> Equip_Inventory_Item;
    public List<int> Equip_Inventory_SlotIndex = new List<int>();

    public List<string> Inventory_Item = new List<string>();
    public List<int> Inventory_SlotIndex = new List<int>();
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

        //LoadingScene.LoadScene("Game");
        string GameData = JsonUtility.ToJson(data, true);
        string path = Path.Combine(Application.persistentDataPath, "Gamedata.json");
        File.WriteAllText(path, GameData);
    }
    [ContextMenu("To Json Data")]
    public void SaveDataToJson()
    {
        if(Inventory.Instance != null)
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
        }

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

        if(Inventory.Instance != null)
        {
            LoadItem();
        }
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
