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
            Time.timeScale = 1;
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
            Time.timeScale = 1;
            StartCoroutine(UI_AnimationManager.instance.Move_Menu_UI());
        }
    }
    public void Exit()
    {
        Time.timeScale = 1;
        Json_DataManager.instance.SaveDataToJson();
        SceneManager.LoadScene("MainScene");
    }
}
