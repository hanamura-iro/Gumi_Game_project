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

    public int Hp; //기본 3칸
    public int Stemina; //기본 5칸
    public int MaxStemina;

    public Image[] HP_Img;
    public Sprite full_HP;
    public Sprite empty_HP;
    public Slider Stemina_Slider;

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
            Player_Status();
        }
        if(Input.GetKeyDown(KeyCode.Q) && Hp > 0)
        {
            Hp--;
            Stemina--;
            Player_H_S_UI();
        }
        if (Input.GetKeyDown(KeyCode.E) && Hp < 6)
        {
            Hp++;
            Stemina++;
            Player_H_S_UI();
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
    void Player_Status()
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
    void Player_H_S_UI() //체력, 스테미나 UI
    {
        switch (Hp)
        {
            case 0:
                for (int i = 0; i < HP_Img.Length; i++)
                {
                    HP_Img[i].sprite = empty_HP;
                }
                break;
            case 1:
                HP_Img[0].sprite = full_HP;
                for (int i = 1; i < HP_Img.Length; i++)
                {
                    HP_Img[i].sprite = empty_HP;
                }
                break;
            case 2:
                HP_Img[0].sprite = full_HP;
                HP_Img[1].sprite = full_HP;
                for (int i = 2; i < HP_Img.Length; i++)
                {
                    HP_Img[i].sprite = empty_HP;
                }
                break;
            case 3:
                HP_Img[0].sprite = full_HP;
                HP_Img[1].sprite = full_HP;
                HP_Img[2].sprite = full_HP;
                for (int i = 3; i < HP_Img.Length; i++)
                {
                    HP_Img[i].sprite = empty_HP;
                }
                break;
            case 4:
                HP_Img[3].gameObject.SetActive(true);
                HP_Img[0].sprite = full_HP;
                HP_Img[1].sprite = full_HP;
                HP_Img[2].sprite = full_HP;
                HP_Img[3].sprite = full_HP;
                HP_Img[0].sprite = full_HP;
                HP_Img[4].sprite = empty_HP;
                HP_Img[5].sprite = empty_HP;
                break;
            case 5:
                HP_Img[4].gameObject.SetActive(true);
                HP_Img[0].sprite = full_HP;
                HP_Img[1].sprite = full_HP;
                HP_Img[2].sprite = full_HP;
                HP_Img[3].sprite = full_HP;
                HP_Img[4].sprite = full_HP;
                HP_Img[5].sprite = empty_HP;
                break;
            case 6:
                HP_Img[5].gameObject.SetActive(true);
                for (int i = 0; i < HP_Img.Length; i++)
                {
                    HP_Img[i].sprite = full_HP;
                }
                break;
        }

        Stemina_Slider.value = Stemina;
        Stemina_Slider.maxValue = MaxStemina;
    }
}
