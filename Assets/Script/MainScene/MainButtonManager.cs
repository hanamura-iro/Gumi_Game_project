using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButtonManager : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("InGame");
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
    #region 설정 화면  
    public Image SettingImg;
    public bool isSetting;

    public Image GameSettingIMG;
    public Image SoundSettingIMG;
    public Image GraphicSettingIMG;
    public Image DevelopersIMG;
    public void GameSettingBtn()
    {
        GameSettingIMG.gameObject.SetActive(true);
        SoundSettingIMG.gameObject.SetActive(false);
        GraphicSettingIMG.gameObject.SetActive(false);
        DevelopersIMG.gameObject.SetActive(false);
    }
    public void SoundSettingBtn()
    {
        GameSettingIMG.gameObject.SetActive(false);
        SoundSettingIMG.gameObject.SetActive(true);
        GraphicSettingIMG.gameObject.SetActive(false);
        DevelopersIMG.gameObject.SetActive(false);
    }
    public void GraphicsSettingBtn()
    {
        GameSettingIMG.gameObject.SetActive(false);
        SoundSettingIMG.gameObject.SetActive(false);
        GraphicSettingIMG.gameObject.SetActive(true);
        DevelopersIMG.gameObject.SetActive(false);
    }
    public void DevelopersBtn()
    {
        GameSettingIMG.gameObject.SetActive(false);
        SoundSettingIMG.gameObject.SetActive(false);
        GraphicSettingIMG.gameObject.SetActive(false);
        DevelopersIMG.gameObject.SetActive(true);
    }
    public void SettingBtn()
    {
        if (!isSetting)
        {
            isSetting = true;
            SettingImg.gameObject.SetActive(true);
        }
        else if (isSetting)
        {
            isSetting = false;
            SettingImg.gameObject.SetActive(false);
        }
    }
    #endregion
}
