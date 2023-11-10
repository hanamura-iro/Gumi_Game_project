using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "DragonLine")
            return;

        if(Player.Instance != null && !Player.Instance.isTutorial)
        {
            StartCoroutine(Move_Camera());
            //transform.position = new Vector3(Player.Instance.transform.position.x, transform.position.y, -8);
        }
        else if(DragonScenePlayerControl.Instance != null)
        {
            transform.position = new Vector3(DragonScenePlayerControl.Instance.transform.position.x, transform.position.y, 12);
        }
    }
    void LateUpdate()
    {
        if (Player.Instance != null)
            if (Player.Instance.isBattle)
                return;

        if (SceneManager.GetActiveScene().name != "DragonLine")
        {
            if(Player.Instance != null)
                if (Player_Interaction.instance.isInHouse)
                    return;

            //µå·¡°ï ¾À Ä«¸Þ¶ó Á¦ÇÑ
            if (SceneManager.GetActiveScene().name == "Dragon")
            {
                if (DragonScenePlayerControl.Instance.transform.position.x >= -17 && DragonScenePlayerControl.Instance.transform.position.x <= 0)
                {
                    if (SettingManager.Instance.isCameraAction)
                    {
                        transform.position = Vector3.Lerp(transform.position, DragonScenePlayerControl.Instance.transform.position, SettingManager.Instance.CameraSmoothIndex * Time.deltaTime);
                        transform.position = new Vector2(transform.position.x, 6);
                    }
                    else
                    {
                        transform.position = new Vector3(DragonScenePlayerControl.Instance.transform.position.x, 6, 12);
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "PlayerCity")
            {
                transform.position = new Vector3(transform.position.x,transform.position.y, -8);
                if (Player.Instance.transform.position.x >= -14f && Player.Instance.transform.position.x <= 14f)
                {
                    if (SettingManager.Instance.isCameraAction)
                    {
                        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -8), new Vector3(Player.Instance.transform.position.x, transform.position.y, -8), SettingManager.Instance.CameraSmoothIndex * Time.deltaTime);
                        transform.position = new Vector3(transform.position.x, transform.position.y, -8);
                    }
                    else
                    {
                        transform.position = new Vector3(Player.Instance.transform.position.x, transform.position.y, -8);
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "DragonCity")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -8);
                if (Player.Instance.transform.position.x >= -36.5f && Player.Instance.transform.position.x <= 36.5f)
                {
                    if (SettingManager.Instance.isCameraAction)
                    {
                        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -8), new Vector3(Player.Instance.transform.position.x, transform.position.y, -8), SettingManager.Instance.CameraSmoothIndex * Time.deltaTime);
                        transform.position = new Vector3(transform.position.x, transform.position.y, -8);
                    }
                    else
                    {
                        transform.position = new Vector3(Player.Instance.transform.position.x, transform.position.y, -8);
                    }
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "DragonLine")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -8);
            if (Player.Instance.transform.position.x >= -50f && Player.Instance.transform.position.x <= 50f)
            {
                if (SettingManager.Instance.isCameraAction)
                {
                    transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -8), new Vector3(Player.Instance.transform.position.x, transform.position.y, -8), SettingManager.Instance.CameraSmoothIndex * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x, transform.position.y, -8);
                }
                else
                {
                    transform.position = new Vector3(Player.Instance.transform.position.x, transform.position.y, -8);
                }
            }
        }
    }

    public float CurTime;
    public IEnumerator Move_Camera()
    {
        Debug.Log("Move_Camera");
        CurTime = 0f;
        while (CurTime < 1)
        {
            CurTime += 0.007f;
            yield return new WaitForSeconds(0.001f);
            //float t = CurMainSettingTime / 1;
            //t = Mathf.Sin(t * Mathf.PI * 0.5f);

            transform.position = Vector2.Lerp(new Vector2(Player.Instance.transform.position.x, 20), new Vector2(Player.Instance.transform.position.x, 4.2f), CurTime);
        }
    }

    public float CurBattleTime;
    public Transform EnemyPos;
    public GameObject Dice;
    public float CenterPos;
    public IEnumerator Move_BattleCamera()
    {
        float posX = Player.Instance.transform.position.x;
        //float CenterPos = Player.Instance.transform.position.x / EnemyPos.transform.position.x;
        CenterPos = Vector2.Distance(new Vector2(Player.Instance.transform.position.x, Player.Instance.transform.position.y), new Vector2(EnemyPos.transform.position.x, EnemyPos.transform.position.y));
        Debug.Log(CenterPos);
        CurBattleTime = 0f;
        while (CurBattleTime < 1)
        {
            CurBattleTime += 0.007f;
            yield return new WaitForSeconds(0.001f);
            //float t = CurMainSettingTime / 1;
            //t = Mathf.Sin(t * Mathf.PI * 0.5f);

            transform.position = Vector2.Lerp(new Vector2(posX, transform.position.y), new Vector2(CenterPos, transform.position.y), CurBattleTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -8f);
        }
        //Instantiate(Dice,new Vector2(CenterPos, 5f), Dice.transform.rotation);
        Tutorial.Instance.NextText();
    }
}
