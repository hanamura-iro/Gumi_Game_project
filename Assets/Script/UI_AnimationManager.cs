using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AnimationManager : MonoBehaviour
{
    public static UI_AnimationManager instance;

    public Image MainSettingImg;
    public Image Player_status;
    public GameObject Quest_Board;
    void Awake()
    {
        instance = this;
    }

    #region 시작화면
    public float CurMainSettingTime;
    public IEnumerator Move_SettingUI()
    {
        CurMainSettingTime = 0f;
        while (CurMainSettingTime < 1)
        {
            CurMainSettingTime += 0.02f;
            yield return new WaitForSeconds(0.001f);
            float t = CurMainSettingTime / 1;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);

            if (SettingButtonManager.Instance.isSetting)
                MainSettingImg.transform.localPosition = Vector2.Lerp(new Vector2(0, 1000), new Vector2(0, 0), t);
            if (!SettingButtonManager.Instance.isSetting)
                MainSettingImg.transform.localPosition = Vector2.Lerp(new Vector2(0, 0), new Vector2(0, 1000), t);
        }
    }
    #endregion
    #region 인게임
    public float CurMenuTime;
    public IEnumerator Move_Menu_UI()
    {
        CurMenuTime = 0f;
        while (CurMenuTime < 1)
        {
            CurMenuTime += 0.02f;
            yield return new WaitForSeconds(0.001f);
            float t = CurMenuTime / 1;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);

            if (GameManager.Instance.isMenu)
                GameManager.Instance.MenuIMG.transform.localPosition = Vector2.Lerp(new Vector2(0, 1200), new Vector2(0, 0), t);
            if (!GameManager.Instance.isMenu)
            {
                GameManager.Instance.MenuIMG.transform.localPosition = Vector2.Lerp(new Vector2(0, 0), new Vector2(0, 1200), t);
            }
        }
    }
    public float CurPlayerStatusTime;
    public IEnumerator Move_Player_StatusUI()
    {
        CurPlayerStatusTime = 0f;
        while (CurPlayerStatusTime < 1)
        {
            CurPlayerStatusTime += 0.02f;
            yield return new WaitForSeconds(0.001f);
            float t = CurPlayerStatusTime / 1;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);

            if(Player.Instance.isInventory)
                Player_status.transform.localPosition = Vector2.Lerp(new Vector2(0, -750), new Vector2(0, -345), t);
            if(!Player.Instance.isInventory)
                Player_status.transform.localPosition = Vector2.Lerp(new Vector2(0, -345), new Vector2(0, -750), t);
        }
    }
    public float CurQuestBoardTime;
    public Image QuestBorade_BG_IMG;
    public IEnumerator Move_QuestBoardUI()
    {
        QuestBorade_BG_IMG.gameObject.SetActive(false);
        CurQuestBoardTime = 0f;
        while (CurQuestBoardTime < 1)
        {
            CurQuestBoardTime += 0.02f;
            yield return new WaitForSeconds(0.001f);
            float t = CurQuestBoardTime / 1;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);

            if (Player_Interaction.instance.isTest)
            {
                Quest_Board.transform.localPosition = Vector2.Lerp(new Vector2(0,1000),new Vector2(0f,195f),t);
                if (CurQuestBoardTime >= 1)
                {
                    QuestBorade_BG_IMG.gameObject.SetActive(true);
                }
            }
            if (!Player_Interaction.instance.isTest)
            {
                Quest_Board.transform.localPosition = Vector2.Lerp(new Vector2(0,195f),new Vector2(0,1000), t);
                if (CurQuestBoardTime <= 0)
                {
                    QuestBorade_BG_IMG.gameObject.SetActive(false);
                }
            }
        }
    }
    #endregion
}
