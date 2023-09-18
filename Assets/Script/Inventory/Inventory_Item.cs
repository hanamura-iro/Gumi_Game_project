using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Inventory_Item : MonoBehaviour ,IBeginDragHandler, IDragHandler ,IEndDragHandler
{
    public static Inventory_Item Instance;
    public Transform Inventory_Content;

    public Transform Item_Inventory_Pos;

    CanvasGroup CG;

    public static GameObject Drag_Item = null;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        Inventory_Content = GameObject.Find("Inventory").GetComponent<Transform>();
        CG = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData) //드래그 시작
    {
        Item_Inventory_Pos = transform.parent;
        Drag_Item = this.gameObject;
        this.transform.SetParent(Inventory_Content);
        CG.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) //드래그 중
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) //드래그 종료
    {
        Drag_Item = null;
        CG.blocksRaycasts = true;
        if (transform.parent == Inventory_Content)
        {
            transform.SetParent(Item_Inventory_Pos);
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
