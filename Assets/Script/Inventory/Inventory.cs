using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [Header("아이템 프리팹")]
    public GameObject Red_Potion;

    [Header("아이템 이미지")]
    public Image Red_PotionIMG;

    [Header("가지고 있는 아이템")]
    public List<GameObject> Inventory_Item = new List<GameObject>();

    [Header("인벤토리 슬롯")]
    public List<GameObject> Inventory_Slot = new List<GameObject>();
    private void Awake()
    {
        Instance = this;
    }
    public bool isSet;
    public void Set_Item(Type type) //아이템 배치
    {
        isSet = true;
        for (int i = 0; i < Inventory_Slot.Count; i++)
        {
            if (Inventory_Slot[i].transform.childCount == 0 && isSet)
            {
                isSet = false;
                if (type == Type.RedPotion)
                {
                    Instantiate(Red_PotionIMG, Inventory_Slot[i].transform);
                }
            }
        }
    }
}
