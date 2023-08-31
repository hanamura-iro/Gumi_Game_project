using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLanguageManager : MonoBehaviour
{
    #region 메인화면
    [Header("메인화면")]
    public Text StartBtnText;
    public Text SettingBtnText;
    public Text ExitBtnText;
    #endregion

    #region 설정화면
    [Header("설정화면 버튼")]
    public Text GameSettingBtnText;
    public Text SoundSettingBtnText;
    public Text GraphicSettingBtnText;
    public Text DevelopersBtnText;
    public Text SettingExitText;

    [Header("설정화면 언어")]
    public Text LanguageSettingTitleText;

    [Header("설정화면 소리")]
    public Text SoundSettingTitleText;
    public Text MasterSoundSettingText;
    public Text BGMSettingText;
    public Text SFXSettingText;
    #endregion
    private void Start()
    {
        if(PlayerPrefs.GetInt("Language") == 0) //0 한국어 1 영어 2 일본어
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
        StartBtnText.text = "계속하기";
        SettingBtnText.text = "설정";
        ExitBtnText.text = "종료";

        if(GameSettingBtnText != null)
        {
            GameSettingBtnText.text = "게임";
            SoundSettingBtnText.text = "소리";
            GraphicSettingBtnText.text = "그래픽";
            DevelopersBtnText.text = "개발자";
            SettingExitText.text = "닫기";
        }

        if(LanguageSettingTitleText != null)
        {
            LanguageSettingTitleText.text = "언어";
        }

        if(SoundSettingTitleText != null)
        {
            SoundSettingTitleText.text = "소리 설정";
            MasterSoundSettingText.text = "마스터";
            BGMSettingText.text = "배경 음악";
            SFXSettingText.text = "효과음";
        }
    }
    public void EnLanguage()
    {
        StartBtnText.text = "Continue";
        SettingBtnText.text = "Setting";
        ExitBtnText.text = "Exit";

        if (GameSettingBtnText != null)
        {
            GameSettingBtnText.text = "GamePlay";
            SoundSettingBtnText.text = "Audio";
            GraphicSettingBtnText.text = "Graphics";
            DevelopersBtnText.text = "Developers";
            SettingExitText.text = "return";
        }

        if (LanguageSettingTitleText != null)
        {
            LanguageSettingTitleText.text = "Language";
        }

        if (SoundSettingTitleText != null)
        {
            SoundSettingTitleText.text = "Audio Setting";
            MasterSoundSettingText.text = "Master";
            BGMSettingText.text = "BGM";
            SFXSettingText.text = "SFX";
        }
    }
    public void jaLanguage()
    {
        StartBtnText.text = "継続";
        SettingBtnText.text = "設定";
        ExitBtnText.text = "終了";

        if (GameSettingBtnText != null)
        {
            GameSettingBtnText.text = "ゲーム";
            SoundSettingBtnText.text = "音";
            GraphicSettingBtnText.text = "グラフィック";
            DevelopersBtnText.text = "開発者";
            SettingExitText.text = "閉じる";
        }

        if (LanguageSettingTitleText != null)
        {
            LanguageSettingTitleText.text = "言語";
        }

        if (SoundSettingTitleText != null)
        {
            SoundSettingTitleText.text = "音設定";
            MasterSoundSettingText.text = "マスター";
            BGMSettingText.text = "BGM";
            SFXSettingText.text = "SFX";
        }
    }
}
