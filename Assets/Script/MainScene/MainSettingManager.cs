using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSettingManager : MonoBehaviour
{
    #region 언어 설정
    //0 한국어 1 영어 2 일본어
    public void KoLanguage()
    {
        PlayerPrefs.SetInt("Language", 0);
        SceneManager.LoadScene("MainScene");
    }
    public void EnLanguage()
    {
        PlayerPrefs.SetInt("Language", 1);
        SceneManager.LoadScene("MainScene");
    }
    public void JaLanguage()
    {
        PlayerPrefs.SetInt("Language", 2);
        SceneManager.LoadScene("MainScene");
    }
    #endregion
}
