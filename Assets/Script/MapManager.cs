using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapManager : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public bool isOnPointerEnter;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        isOnPointerEnter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        isOnPointerEnter = false;
    }
    public Image Map_IMG;
    private void Update()
    {
        if(isOnPointerEnter)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (Map_IMG.transform.localScale.x <= 3f)
                {
                    Map_IMG.transform.localScale = new Vector3(Map_IMG.transform.localScale.x + 0.1f, Map_IMG.transform.localScale.y + 0.1f, Map_IMG.transform.localScale.y + 0.1f);
                }
                Debug.Log("확대");
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (Map_IMG.transform.localScale.x >= 0.9f)
                {
                    Map_IMG.transform.localScale = new Vector3(Map_IMG.transform.localScale.x - 0.1f, Map_IMG.transform.localScale.y - 0.1f, Map_IMG.transform.localScale.y - 0.1f);
                }
                Debug.Log("축소");
            }
        }
    }
}
