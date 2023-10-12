using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum Type //아이템 종류
{
    RedPotion,
    bow,
    bat
}
public class Item : MonoBehaviour
{
    Rigidbody2D rigid;
    public Type type;
    public bool isEat;
    public bool isCollision;

    public bool isDrop;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        if(isDrop)
        {
            rigid.AddForce(Vector2.up * 2,ForceMode2D.Impulse);
            if(Player.Instance.transform.localScale == new Vector3(1,1,1))
                rigid.AddForce(Vector2.right * 2 ,ForceMode2D.Impulse);
            if (Player.Instance.transform.localScale == new Vector3(-1, 1, 1))
                rigid.AddForce(Vector2.left * 2, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isCollision = true;
            isEat = true;
        }
    }
    private void Update()
    {
        if(isCollision && Input.GetKeyDown(KeyCode.F))
        {
            isCollision = false;
            for (int i = 0; i < Inventory.Instance.Inventory_Slot.Count; i++)
            {
                if (Inventory.Instance.Inventory_Slot[i].transform.childCount == 0 && isEat)
                {
                    isEat = false;
                    if (type == Type.RedPotion)
                    {
                        Inventory.Instance.Set_Item(Type.RedPotion);
                        Destroy(this.gameObject);
                    }
                    else if (type == Type.bow)
                    {
                        Inventory.Instance.Set_Item(Type.bow);
                        Destroy(this.gameObject);
                    }
                    else if (type == Type.bat)
                    {
                        Inventory.Instance.Set_Item(Type.bat);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isCollision = false;
            isEat = false;
        }
    }
}
    