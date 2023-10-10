using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance;
    #region 언어 설정
    private void Awake()
    {
        Instance = this;
    }
    //0 한국어 1 영어 2 일본어
    public void KoLanguage()
    {
        PlayerPrefs.SetInt("Language", 0);
        LoadingScene.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void EnLanguage()
    {
        PlayerPrefs.SetInt("Language", 1);
        LoadingScene.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void JaLanguage()
    {
        PlayerPrefs.SetInt("Language", 2);
        LoadingScene.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
    #region 카메라 설정
    public Toggle CameraActionToggle;
    public int CameraSmoothIndex;
    public Text CameraSmoothIndexText;
    public bool isCameraAction;
    public GameObject SmoothSetting;
    public void CameraAction()
    {
        if (isCameraAction)
        {
            isCameraAction = false;
            SmoothSetting.SetActive(false);
            CameraActionToggle.SetIsOnWithoutNotify(isCameraAction);
        }
        else if (!isCameraAction)
        {
            isCameraAction = true;
            SmoothSetting.SetActive(true);
            CameraActionToggle.SetIsOnWithoutNotify(isCameraAction);
        }
    }
    public void UpBtn()
    {
        if(CameraSmoothIndex >= 1 && CameraSmoothIndex < 10) 
        {
            CameraSmoothIndex++;
            CameraSmoothIndexText.text = CameraSmoothIndex + "";
        }
    }
    public void DownBtn()
    {
        if(CameraSmoothIndex > 1 && CameraSmoothIndex <= 10)
        { 
            CameraSmoothIndex--;
            CameraSmoothIndexText.text = CameraSmoothIndex + "";
        }
    }
    #endregion
}
