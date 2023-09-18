using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Gold;
    public Text Gold_Text;

    public Image MenuIMG;
    public bool isMenu;
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        Menu();

        Gold_Text.text = Gold.ToString("N0");
    }
    void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isMenu)
        {
            isMenu = true;
            MenuIMG.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isMenu)
        {
            isMenu = false;
            MenuIMG.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void MenuBtn()
    {
        isMenu = true;
        MenuIMG.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ConBtn()
    {
        if (isMenu)
        {
            isMenu = false;
            MenuIMG.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
}
