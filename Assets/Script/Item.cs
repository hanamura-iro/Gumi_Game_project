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
    public bool isEat;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isEat = true;
            for (int i = 0; i < Inventory.Instance.Inventory_Slot.Count; i++)
            {
                if (Inventory.Instance.Inventory_Slot[i].transform.childCount == 0 && isEat)
                {
                    if (type == Type.RedPotion)
                    {
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
                    isEat = false;
                }
            }
        }
    }
}
    