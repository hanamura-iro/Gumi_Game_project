using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Inventory_Item : MonoBehaviour ,IBeginDragHandler, IDragHandler ,IEndDragHandler ,IPointerEnterHandler, IPointerExitHandler
{
    public static Inventory_Item Instance;
    public Transform Inventory_Content;

    //public Transform Item_Inventory_Pos;

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
        Debug.Log("OnBeginDrag");
        //Item_Inventory_Pos = transform.parent;
        transform.SetParent(Inventory_Content);
        Drag_Item = gameObject;
        CG.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) //드래그 중
    {
        Debug.Log("OnDrag");
        transform.position = Input.mousePosition;
    }
    public GameObject DropItem; //드랍 할 아이템
    public void OnEndDrag(PointerEventData eventData) //드래그 종료
    {
        CG.blocksRaycasts = true;
        if (transform.parent == Inventory_Content)
        {
            Debug.Log("OnEndDrag");
            //transform.SetParent(Item_Inventory_Pos);
            //transform.localPosition = new Vector3(0, 0, 0);


            if (Drag_Item.name == "Red_potionIMG(Clone)")
                DropItem = Instantiate(Inventory.Instance.Red_Potion);
            if (Drag_Item.name == "BowIMG(Clone)")
                DropItem = Instantiate(Inventory.Instance.Bow);
            if (Drag_Item.name == "BatIMG(Clone)")
                DropItem = Instantiate(Inventory.Instance.Bat);

            if (Player.Instance.transform.localScale == new Vector3(1, 1, 1))
                DropItem.transform.position = new Vector3(Player.Instance.transform.position.x + 1.2f, Player.Instance.transform.position.y, 0);
            if (Player.Instance.transform.localScale == new Vector3(-1, 1, 1))
                DropItem.transform.position = new Vector3(Player.Instance.transform.position.x - 1.2f, Player.Instance.transform.position.y, 0);

            Destroy(gameObject);
        }
        Drag_Item = null;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");

        if (this.gameObject.name == "Red_potionIMG(Clone)")
        {
            Inventory.Instance.Item_DescriptionIMG.transform.position = new Vector2(Input.mousePosition.x + 215, Input.mousePosition.y + 215);
            Inventory.Instance.Item_DescriptionIMG.gameObject.SetActive(true);
            Inventory.Instance.Item_IMG.sprite = Inventory.Instance.Red_PotionSprite;
            Inventory.Instance.Item_Name.text = "빨간 물약\n<color=#FF0000>R</color>등급\n판매가 : <color=#ECC041>70G</color>";
            Inventory.Instance.Item_Description.text = "아이템을 섭취시 <color=#FFFFFF>그것</color>이 뛰어나게 좋아집니다.\n남자들에겐 인기만점 아이템입니다.";
        }
        if (this.gameObject.name == "Bat(Clone)")
        {
            Inventory.Instance.Item_DescriptionIMG.transform.position = new Vector2(Input.mousePosition.x + 215, Input.mousePosition.y + 215);
            Inventory.Instance.Item_DescriptionIMG.gameObject.SetActive(true);
            Inventory.Instance.Item_IMG.sprite = Inventory.Instance.BatSprite;
            Inventory.Instance.Item_Name.text = "빨강 슬라임\n<color=#FFFF00>Y</color>등급\n판매가 : <color=#ECC041>40G</color>";
            Inventory.Instance.Item_Description.text = "나무 방망이";
        }
        if (this.gameObject.name == "Bow(Clone)")
        {
            Inventory.Instance.Item_DescriptionIMG.transform.position = new Vector2(Input.mousePosition.x + 215, Input.mousePosition.y + 215);
            Inventory.Instance.Item_DescriptionIMG.gameObject.SetActive(true);
            Inventory.Instance.Item_IMG.sprite = Inventory.Instance.BowSprite;
            Inventory.Instance.Item_Name.text = "활\n<color=#0000FF>B</color>등급\n판매가 : <color=#ECC041>300G</color>";
            Inventory.Instance.Item_Description.text = "나무 활";
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");

        Inventory.Instance.Item_DescriptionIMG.gameObject.SetActive(false);
    }
}
