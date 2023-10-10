using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    void LateUpdate()
    {
        //µå·¡°ï ¾À Ä«¸Þ¶ó Á¦ÇÑ
        if(Player.Instance.transform.position.x >= -17 && Player.Instance.transform.position.x <= 0)
        {
            transform.position = new Vector3(Player.Instance.transform.position.x,6,12);
        }
    }
}
