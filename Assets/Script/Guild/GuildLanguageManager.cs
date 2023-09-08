using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuildGameLanguageManager : MonoBehaviour
{
    #region 메뉴 텍스트
    public Text ContBtnText;
    public Text SettingText;
    public Text ExitBtnText;
    #endregion
    private void Start()
    {
        if (PlayerPrefs.GetInt("Language") == 0) //0 한국어 1 영어 2 일본어
        {
            KoLanguage();
        }
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            EnLanguage();
        }
        if (PlayerPrefs.GetInt("Language") == 2)
        {
            jaLanguage();
        }
    }

    public void KoLanguage()
    {
        if(ContBtnText != null)
        {
            ContBtnText.text = "계속하기";
            //SettingText.text = "설정";
            ExitBtnText.text = "나가기";
        }
    }
    public void EnLanguage()
    {
        if (ContBtnText != null)
        {
            ContBtnText.text = "continue";
            //SettingText.text = "Setting";
            ExitBtnText.text = "Exit";
        }
    }
    public void jaLanguage()
    {
        if (ContBtnText != null)
        {
            ContBtnText.text = "続ける";
            //SettingText.text = "設定";
            ExitBtnText.text = "終了";
        }
    }
}
