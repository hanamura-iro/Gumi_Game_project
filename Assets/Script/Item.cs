using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type //아이템 종류
{
    RedPotion,
    bow,
    bat
}
public class Item : MonoBehaviour
{
    public Type type;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            if(type == Type.RedPotion)
            {
                //Inventory.Instance.Inventory_Item.Add(Inventory.Instance.Red_Potion);
                Inventory.Instance.Set_Item(Type.RedPotion);
                Destroy(this.gameObject);
            }
            if (type == Type.bow)
            {
                Inventory.Instance.Set_Item(Type.bow);
                Destroy(this.gameObject);
            }
            if (type == Type.bat)
            {
                Inventory.Instance.Set_Item(Type.bat);
                Destroy(this.gameObject);
            }
        }
    }
}
    