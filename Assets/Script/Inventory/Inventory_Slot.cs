using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Slot_Type
{
    Inventory,
    Armor,
    Hand,
    accessories
}
public class Inventory_Slot : MonoBehaviour, IDropHandler
{
    public Slot_Type type;
    Image Slot;
    public GameObject Inventory_Child_Item;
    private void Awake()
    {
        Slot = GetComponent<Image>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            if (type == Slot_Type.Inventory)
            {
                Inventory_Item.Drag_Item.transform.SetParent(this.transform);
                Inventory_Item.Drag_Item.transform.localPosition = new Vector3(0, 0, 0);
            }
            equip_Hand();
            equip_Armor();
            equip_Accessories();
        }
    }
    void equip_Hand()
    {
        if (type == Slot_Type.Hand)
        {
            if (Inventory_Item.Drag_Item.name == "Bat(Clone)" || Inventory_Item.Drag_Item.name == "Red_potionIMG(Clone)")
            {
                Inventory_Item.Drag_Item.transform.SetParent(this.transform);
                Inventory_Item.Drag_Item.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
    void equip_Armor()
    {
        if (type == Slot_Type.Armor)
        {
            if (Inventory_Item.Drag_Item.name == "Armor")
            {
                Inventory_Item.Drag_Item.transform.SetParent(this.transform);
                Inventory_Item.Drag_Item.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
    void equip_Accessories()
    {
        if (type == Slot_Type.accessories)
        {
            if (Inventory_Item.Drag_Item.name == "Bow(Clone)")
            {
                Inventory_Item.Drag_Item.transform.SetParent(this.transform);
                Inventory_Item.Drag_Item.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
    private void Update()
    {
        if (this.transform.childCount == 0)
        {
            Slot.color = new Color(1, 1, 1, 1);
        }
        if (this.transform.childCount == 1)
        {
            Inventory_Child_Item = this.transform.GetChild(0).gameObject;
            if (Inventory_Child_Item.CompareTag("Rating_Red"))
            {
                Slot.color = new Color(1, 0, 0, 1);
            }
            if (Inventory_Child_Item.CompareTag("Rating_Yellow"))
            {
                Slot.color = new Color(1, 0.8f, 0, 1);
            }
            if (Inventory_Child_Item.CompareTag("Rating_Blue"))
            {
                Slot.color = new Color(0, 0, 1, 1);
            }
        }
    }
}
