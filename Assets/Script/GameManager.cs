using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Image MenuIMG;
    public bool isMenu;
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        Menu();
    }
    public void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isMenu)
        {
            isMenu = true;
            StartCoroutine(UI_AnimationManager.instance.Move_Menu_UI());
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isMenu)
        {
            isMenu = false;
            //Time.timeScale = 1;
            if(SettingButtonManager.Instance.isSetting)
            {
                SettingButtonManager.Instance.isSetting = false;
                StartCoroutine(UI_AnimationManager.instance.Move_SettingUI());
            }
            StartCoroutine(UI_AnimationManager.instance.Move_Menu_UI());
        }
    }
    public void MenuBtn()
    { 
        isMenu = true;
        StartCoroutine(UI_AnimationManager.instance.Move_Menu_UI());
    }
    public void ConBtn()
    {
        if (isMenu)
        {
            isMenu = false;
            //Time.timeScale = 1;
            if (SettingButtonManager.Instance.isSetting)
            {
                SettingButtonManager.Instance.isSetting = false;
                StartCoroutine(UI_AnimationManager.instance.Move_SettingUI());
            }
            StartCoroutine(UI_AnimationManager.instance.Move_Menu_UI());
        }
    }
    public void Exit()
    {
<<<<<<< HEAD
        Time.timeScale = 1;
        //Json_DataManager.instance.SaveDataToJson();
=======
        //Time.timeScale = 1;
        if(Json_DataManager.instance != null)
            Json_DataManager.instance.SaveDataToJson();
>>>>>>> 2c2e204226bad7f1e52d0a94b52623950b0e2b2a
        SceneManager.LoadScene("MainScene");
    }
}
