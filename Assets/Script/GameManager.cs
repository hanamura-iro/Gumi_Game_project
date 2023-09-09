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
    public void Update()
    {
        if(!isMenu && Input.GetKeyDown(KeyCode.Escape))
        {
            isMenu = true;
            MenuIMG.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if(isMenu && Input.GetKeyDown(KeyCode.Escape))
        {
            isMenu = false;
            MenuIMG.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        Gold_Text.text = Gold.ToString("N0");
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
