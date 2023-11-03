using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    Animator ani;

    [Header("플레이어 스탯")]
    public int movePower = 1;
    public int jumpPower = 1;
    public int Hp; //기본 3칸
    public int MaxHP;
    public int Stemina; //기본 5칸
    public int MaxStemina;

    [Header("플레이어 Ability")]
    public int Health;
    public Text HealthText;
    public int Power;
    public Text PowerText;
    public int Wisdom;
    public Text WisdomText;
    public int Speed;
    public Text SpeedText;
    public int Intelligence;
    public Text IntelligenceText;
    public int Charm;
    public Text CharmText;

    [Header("플레이어의 돈")]
    public int Gold;
    public Text Gold_Text;

    public Image[] HP_Img;
    public Sprite full_HP;
    public Sprite empty_HP;
    public Slider Stemina_Slider;
    public Text Stemina_Text;

    public bool isInventory;
    private void Awake()
    {
        Instance = this;

        ani = GetComponent<Animator>();
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Dragon")
        {
            transform.position = new Vector3(-17, 2, 30);
        }
    }
    void Update()
    {
        Gold_Text.text = Gold.ToString("N0");
        if(QuestManager.Instance.Quest_Name.Count >= 1)
            Quest_Text.text = QuestManager.Instance.Quest_Name[QuestIndex] + "\n" + QuestManager.Instance.Quest_Ex[QuestIndex];
        if (!GameManager.Instance.isMenu)
        {
            Move();
            Run();
        }
        Player_Status();
        AbilityText();
        Player_H_S_UI();
        #region 게임 낼 때 지워야 할 것
        if (Input.GetKeyDown(KeyCode.Q) && Hp > 0)
        {
            Hp--;
            Stemina--;
        }
        if (Input.GetKeyDown(KeyCode.E) && Hp < 6)
        {
            Hp++;
            Stemina++;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            MaxHP++;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Json_DataManager.instance.ResetDataToJson();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadingScene.LoadScene("PlayerCity");
            Json_DataManager.instance.SaveDataToJson();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadingScene.LoadScene("DragonCity");
            Json_DataManager.instance.SaveDataToJson();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LoadingScene.LoadScene("Dragon");
            Json_DataManager.instance.SaveDataToJson();
        }

        #endregion
    }
    public void AbilityText()
    {
        HealthText.text = Health + "";
        PowerText.text = Power + "";
        WisdomText.text = Wisdom + "";
        SpeedText.text = Speed + "";
        IntelligenceText.text = Intelligence + "";
        CharmText.text = Charm + "";
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * movePower * Time.deltaTime;
            ani.SetBool("Walk",true);
            transform.localScale = new Vector3(-1, 1, 1);
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
            ani.SetFloat("WalkSpeed", 2);
        }
        else
        {
            movePower = 3;
            ani.SetFloat("WalkSpeed", 1);
        }
    }
    void Player_Status() //플레이어 체력,스테미나,인벤토리 UI
    {
        if(!isInventory && Input.GetKeyDown(KeyCode.Tab))
        {
            isInventory = true;
            StartCoroutine(UI_AnimationManager.instance.Move_Player_StatusUI());
            StartCoroutine(Move_Camera());
        }
        else if(isInventory && Input.GetKeyDown(KeyCode.Tab))
        {
            isInventory = false;
            StartCoroutine(UI_AnimationManager.instance.Move_Player_StatusUI());
            StartCoroutine(Move_Camera());
        }
    }
    public void Player_H_S_UI() //체력, 스테미나 UI
    {
        if(MaxHP >= 4)
        {
            HP_Img[3].gameObject.SetActive(true);
        }
        if (MaxHP >= 5)
        {
            HP_Img[4].gameObject.SetActive(true);
        }
        if (MaxHP >= 6)
        {
            HP_Img[5].gameObject.SetActive(true);
        }

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
                HP_Img[0].sprite = full_HP;
                HP_Img[1].sprite = full_HP;
                HP_Img[2].sprite = full_HP;
                HP_Img[3].sprite = full_HP;
                HP_Img[0].sprite = full_HP;
                HP_Img[4].sprite = empty_HP;
                HP_Img[5].sprite = empty_HP;
                break;
            case 5:
                HP_Img[0].sprite = full_HP;
                HP_Img[1].sprite = full_HP;
                HP_Img[2].sprite = full_HP;
                HP_Img[3].sprite = full_HP;
                HP_Img[4].sprite = full_HP;
                HP_Img[5].sprite = empty_HP;
                break;
            case 6:
                for (int i = 0; i < HP_Img.Length; i++)
                {
                    HP_Img[i].sprite = full_HP;
                }
                break;
        }

        Stemina_Slider.value = Stemina;
        Stemina_Slider.maxValue = MaxStemina;
        Stemina_Text.text = Stemina + " / " + MaxStemina;
    }
    public int QuestIndex;
    public Image Quest_IMG;
    public Text Quest_Text;
    public Image Map_IMG;
    public void Quest_Btn()
    {
        Quest_IMG.gameObject.SetActive(true);
        Map_IMG.gameObject.SetActive(false);
    }
    public void QuestIndexLeft()
    {
        if(QuestIndex > 0 && QuestIndex < QuestManager.Instance.Quest_Name.Count)
        {
            QuestIndex--;
        }
    }
    public void QuestIdexRight()
    {
        if (QuestIndex < QuestManager.Instance.Quest_Name.Count -1 && QuestIndex >= 0)
        {
            QuestIndex++;
        }
    }
    public void Map_Btn()
    {
        Quest_IMG.gameObject.SetActive(false);
        Map_IMG.gameObject.SetActive(true);
    }

    public void Stemina_Ui_Enter()
    {
        Stemina_Text.gameObject.SetActive(true);
    }
    public void Stemina_Ui_Exit()
    {
        Stemina_Text.gameObject.SetActive(false);
    }

    public float CurCmaeraTime;
    public Camera cam;
    public IEnumerator Move_Camera()
    {
        Debug.Log("Camera Moving");
        CurCmaeraTime = 0f;
        while (CurCmaeraTime < 1)
        {
            CurCmaeraTime += 0.03f;
            yield return new WaitForSeconds(0.001f);
            //float t = CurCmaeraTime / 1;
            //t = Mathf.Sin(t * Mathf.PI * 0.5f);

            if (isInventory)
                cam.transform.position = Vector2.Lerp(new Vector2(cam.transform.position.x, 4.2f), new Vector2(cam.transform.position.x, 1.4f), CurCmaeraTime);
            else if (!isInventory)
                cam.transform.position = Vector2.Lerp(new Vector2(cam.transform.position.x, 1.4f), new Vector2(cam.transform.position.x, 4.2f), CurCmaeraTime);
        }
    }
}
