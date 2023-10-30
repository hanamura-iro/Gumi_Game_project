using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Item_Type
{
    Red_Potion,
    Bow,
    Bat
}

public class Item_Interaction : MonoBehaviour, IPointerDownHandler
{
    public Item_Type Item_Type;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(1))
        {
            Use_Item();
        }
    }
    void Use_Item() //아이템 사용
    {
        switch (Item_Type)
        {
            case Item_Type.Red_Potion:
                if(Player.Instance.Hp < Player.Instance.MaxHP)
                {
                    Player.Instance.Hp++;
                    Destroy(this.gameObject);
                    Debug.Log("빨간 물약 사용 함");
                    Inventory.Instance.Item_DescriptionIMG.gameObject.SetActive(false);
                }
                break;
            case Item_Type.Bow:
                Debug.Log("사용 아이템 아님");
                break;
            case Item_Type.Bat:
                Debug.Log("사용 아이템 아님");
                break;
        }
    }
}
