using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    Animator ani;

    public int movePower = 1;
    public int jumpPower = 1;

    public bool isInventory;
    public Image InventoryIMG;
    private void Awake()
    {
        Instance = this;

        ani = GetComponent<Animator>();
    }
    void Update()
    {
        if(!GameManager.Instance.isMenu)
        {
            Move();
            Run();
            Player_interaction();
        }
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * movePower * Time.deltaTime;
            ani.SetBool("Walk",true);
            transform.localScale = new Vector3(-1, 1,1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * movePower * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);
            ani.SetBool("Walk", true);
        }
        else 
        {
            ani.SetBool("Walk", false);
        }
    }
    void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            movePower = 9;
        }
        else
        {
            movePower = 3;
        }
    }
    void Player_interaction()
    {
        if(!isInventory && Input.GetKeyDown(KeyCode.Tab))
        {
            isInventory = true;
            InventoryIMG.gameObject.SetActive(true);
        }
        else if(isInventory && Input.GetKeyDown(KeyCode.Tab))
        {
            isInventory = false;
            InventoryIMG.gameObject.SetActive(false);
        }
    }
}
