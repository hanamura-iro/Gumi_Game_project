using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class Data
{
    public List<Transform> SlotTransfrom = new List<Transform>(); 
    public List<GameObject> Slot_Item = new List<GameObject>();
    //public bool KeyChange;
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
        data.SlotTransfrom = new List<Transform>();
        data.Slot_Item = new List<GameObject>();

        //LoadingScene.LoadScene("Game");
        string GameData = JsonUtility.ToJson(data, true);
        string path = Path.Combine(Application.persistentDataPath, "Gamedata.json");
        File.WriteAllText(path, GameData);
    }
    [ContextMenu("To Json Data")]
    public void SaveDataToJson()
    {
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

        Debug.Log("로드 완료");
        SaveDataToJson();
    }
}
