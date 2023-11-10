using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour //플레이어 시티에서 게임 시작시 나오는 튜토리얼 스크립트
{
    public static Tutorial Instance;

    public Text GodText;
    public string StoryString;
    public float TypingSpeed;
    public int TextIndex = 0;
    public bool isTyping;

    public Image TouchBox;//터치 화면
    public Text PlayerText;

    public int TextUser; // 튜토리얼 (0신 1플레이어) 2 평소

    [Header("TextBox")]
    public GameObject TextBoxObj;
    public Text TextBox_Text;

    public GameObject[] TutorialItems;

    public Image TextBoxPlayerIMG;
    public Image TextBoxotherIMG;

    public Sprite[] OtherSprite; //0 신 //1 부상자
    //public GameObject BeaMonster;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        NextText();
    }
    public Image GodIMG;
    public void NextText()
    {
        Debug.Log("TextTyping");
        if (!isTyping)
        {
            TextIndex++;
            switch (TextIndex)
            {
                case 1:
                    Player.Instance.isStory = true;
                    Player.Instance.isTutorial = true;
                    TypingSpeed = 0.3f;
                    TextUser = 0;
                    StoryString = "일어나";
                    StartCoroutine(Story_Typing());
                    break;
                case 2:
                    TypingSpeed = 0.07f;
                    TextUser = 1;
                    StoryString = "무..무슨 일이죠?\n당신은 누구고..";
                    StartCoroutine(Story_Typing());
                    break;
                case 3:
                    TextUser = 0;
                    StoryString = "그건 나중에 설명 해줄게\n마을이 습격 당했어!";
                    StartCoroutine(Story_Typing());
                    GodIMG.gameObject.SetActive(true);
                    break;
                case 4:
                    StoryString = "일단 무기와 갑옷을 챙기고 나가!";
                    StartCoroutine(Story_Typing());
                    break;
                case 5:
                    TouchBox.gameObject.SetActive(false);   
                    Player.Instance.isStory = false;
                    GodIMG.gameObject.SetActive(false);
                    TextBoxObj.SetActive(false);
                    Invoke("False", 0.5f);
                    TextBoxotherIMG.color = new Color(1, 1, 1, 0);
                    TouchBox.color = new Color(1, 1, 1, 0);
                    StoryString = "";
                    Player.Instance.isTutorial = false;
                    StartCoroutine(Story_Typing());
                    break;
                case 6:
                    Player.Instance.isStory = true;
                    TextUser = 2;
                    TextBoxPlayerIMG.color = new Color(1, 1, 1, 1);
                    TouchBox.gameObject.SetActive(true);
                    TextBoxObj.SetActive(true);
                    StoryString = "마을이 불타고 있어!";
                    StartCoroutine(Story_Typing());
                    break;
                case 7:
                    StoryString = "저 사람 한테 한번 물어보자";
                    StartCoroutine(Story_Typing());
                    break;
                case 8:
                    Player.Instance.isStory = false;
                    TouchBox.gameObject.SetActive(false);
                    TextBoxObj.SetActive(false);
                    StoryString = "";
                    StartCoroutine(Story_Typing());
                    break;
                case 9:
                    Player.Instance.isStory = true;
                    TouchBox.gameObject.SetActive(true);
                    TextBoxObj.SetActive(true);
                    StoryString = "무슨 일이 있었던 거죠?!";
                    StartCoroutine(Story_Typing());
                    break;
                case 10:
                    TextBoxotherIMG.gameObject.transform.localScale = new Vector3(2, 2, 2);
                    TextBoxPlayerIMG.color = new Color(0.3f, 0.3f, 0.3f, 1);
                    TextBoxotherIMG.color = new Color(1, 1, 1, 1f);
                    TextBoxotherIMG.sprite = OtherSprite[1];
                    StoryString = "윽... 마을이 괴상하게 생긴\n놈에게 습격 당했어..";
                    StartCoroutine(Story_Typing());
                    break;
                case 11:
                    StoryString = "바로 앞에 놈이 있을거야..";
                    StartCoroutine(Story_Typing());
                    break;
                case 12:
                    Player.Instance.isStory = false;
                    //BeaMonster.SetActive(true);
                    TextBoxotherIMG.color = new Color(1, 1, 1, 0);
                    //TextBoxotherIMG.gameObject.transform.localScale = new Vector3(1, 1, 1);
                    TouchBox.gameObject.SetActive(false);
                    TextBoxObj.SetActive(false);
                    StoryString = "";
                    StartCoroutine(Story_Typing());
                    break;
                case 13:
                    TextBoxPlayerIMG.color = new Color(1, 1, 1, 0);
                    Player.Instance.isStory = true;
                    TextBoxotherIMG.color = new Color(1, 1, 1, 1);
                    TextBoxotherIMG.sprite = OtherSprite[0];
                    TextBoxObj.SetActive(true);
                    TouchBox.gameObject.SetActive(true);
                    //TextBoxotherIMG.gameObject.transform.localScale = new Vector3(1, 1, 1);
                    StoryString = "싸우기 전에 이걸 줄게!\n너에게 행운을 가져다 줄거야";
                    StartCoroutine(Story_Typing());
                    break;
                case 14:
                    StoryString = "한번 굴려봐!";
                    StartCoroutine(Story_Typing());
                    break;
                case 15:
                    Player.Instance.isStory = false;
                    TextBoxotherIMG.color = new Color(1, 1, 1, 0);
                    TextBoxObj.SetActive(false);
                    TouchBox.gameObject.SetActive(false);
                    StoryString = "";
                    StartCoroutine(Story_Typing());
                    Instantiate(CameraManager.Instance.Dice, new Vector2(CameraManager.Instance.CenterPos, 5f), CameraManager.Instance.Dice.transform.rotation);
                    break;
                case 16:
                    TextBoxPlayerIMG.color = new Color(1f, 1f, 1f, 1);
                    Player.Instance.isStory = true;
                    TouchBox.gameObject.SetActive(true);
                    TextBoxObj.SetActive(true);
                    StoryString = "괜찮으신가요?";
                    StartCoroutine(Story_Typing());
                    break;
                case 17:
                    TextBoxotherIMG.gameObject.transform.localScale = new Vector3(2, 2, 2);
                    TextBoxPlayerIMG.color = new Color(0.3f, 0.3f, 0.3f, 1);
                    TextBoxotherIMG.color = new Color(1, 1, 1, 1f);
                    TextBoxotherIMG.sprite = OtherSprite[1];
                    StoryString = "괜찮아..";
                    StartCoroutine(Story_Typing());
                    break;
                case 18:
                    Player.Instance.isStory = false;
                    //BeaMonster.SetActive(true);
                    TextBoxotherIMG.color = new Color(1, 1, 1, 0);
                    //TextBoxotherIMG.gameObject.transform.localScale = new Vector3(1, 1, 1);
                    TouchBox.gameObject.SetActive(false);
                    TextBoxObj.SetActive(false);
                    StoryString = "";
                    StartCoroutine(Story_Typing());
                    break;
            }
        }
    }
    IEnumerator Story_Typing()
    {
        isTyping = true;
        GodText.text = "";
        PlayerText.text = "";
        TextBox_Text.text = "";
        for (int i = 0; i <= StoryString.Length; i++)
        {
            if(TextUser == 0)
                GodText.text = StoryString.Substring(0, i);
            if (TextUser == 1)
                PlayerText.text = StoryString.Substring(0, i);
            if (TextUser == 2)
                TextBox_Text.text = StoryString.Substring(0, i);

            yield return new WaitForSeconds(TypingSpeed);
        }
        isTyping = false;
    }
    public void False()
    {
        TouchBox.gameObject.SetActive(false);
    }
}
