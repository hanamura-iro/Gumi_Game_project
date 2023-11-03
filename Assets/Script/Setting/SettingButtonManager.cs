using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingButtonManager : MonoBehaviour
{
    public static SettingButtonManager Instance;
    public void StartBtn()
    {
        LoadingScene.LoadScene(Json_DataManager.instance.data.SceneName);
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
    #region 설정 화면  
    public bool isSetting;

    public Image GameSettingIMG;
    public Image SoundSettingIMG;
    public Image GraphicSettingIMG;
    public Image DevelopersIMG;
    private void Awake()
    {
        Instance = this;
    }
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
            StartCoroutine(UI_AnimationManager.instance.Move_SettingUI());
        }
        else if (isSetting)
        {
            isSetting = false;
            StartCoroutine(UI_AnimationManager.instance.Move_SettingUI());
            Json_DataManager.instance.SaveDataToJson();
        }
    }
    #endregion
}
