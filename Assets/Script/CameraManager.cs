using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    private void Start()
    {
        if(Player.Instance != null)
        {
            transform.position = new Vector3(Player.Instance.transform.position.x, transform.position.y, -8);
        }
        else if(DragonScenePlayerControl.Instance != null)
        {
            transform.position = new Vector3(DragonScenePlayerControl.Instance.transform.position.x, transform.position.y, 12);
        }
    }
    void LateUpdate()
    {
        //µå·¡°ï ¾À Ä«¸Þ¶ó Á¦ÇÑ
        if(SceneManager.GetActiveScene().name == "Dragon")
        {
            if (DragonScenePlayerControl.Instance.transform.position.x >= -17 && DragonScenePlayerControl.Instance.transform.position.x <= 0)
            {
                if (SettingManager.Instance.isCameraAction)
                {
                    transform.position = Vector3.Lerp(transform.position, DragonScenePlayerControl.Instance.transform.position, SettingManager.Instance.CameraSmoothIndex * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x, 6, 12);
                }
                else
                {
                    transform.position = new Vector3(DragonScenePlayerControl.Instance.transform.position.x, 6, 12);
                }
            }
        }
        else //ÀÏ¹Ý ¾À
        {
            if (SettingManager.Instance.isCameraAction)
            {
                transform.position = Vector3.Lerp(new Vector3(transform.position.x,transform.position.y,-8),new Vector3(Player.Instance.transform.position.x,transform.position.y,-8), SettingManager.Instance.CameraSmoothIndex * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, transform.position.y, -8);
            }
            else
            {
                transform.position = new Vector3(Player.Instance.transform.position.x, transform.position.y, -8);
            }
        }
    }
}
