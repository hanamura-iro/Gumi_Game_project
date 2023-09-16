using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type //아이템 종류
{
    RedPotion
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
                //Inventory.Instance.Items.Add(Inventory.Instance.Red_potion);
                //Inventory.Instance.Set_Inventory();
                Destroy(gameObject);
            }
        }
    }
}
    