using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapProgress : MonoBehaviour
{
    public int MapProgressIndex = -1;
    public Image[] MapProgressIMG;

    public Collider2D[] colls;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pos1"))
        {
            MapProgressIndex++;
            MapProgressIMG[MapProgressIndex].color = new Color(0.5f, 0, 0, 1);
            Collider2D coll = collision;
            coll.isTrigger = false;
        }
        else if (collision.CompareTag("Pos2"))
        {
            MapProgressIndex++;
            MapProgressIMG[MapProgressIndex].color = new Color(0.5f, 0, 0, 1);
            Collider2D coll = collision;
            coll.isTrigger = false;
        }
        else if (collision.CompareTag("Pos3"))
        {
            MapProgressIndex++;
            MapProgressIMG[MapProgressIndex].color = new Color(0.5f, 0, 0, 1);
            Collider2D coll = collision;
            coll.isTrigger = false;
        }
        else if (collision.CompareTag("Pos4"))
        {
            if(MapProgressIndex >= 12)
            {
                LoadingScene.LoadScene("Dragon");
            }
            for (int i = 0; i < 2; i++)
            {
                MapProgressIndex++;
                MapProgressIMG[MapProgressIndex].color = new Color(0.5f, 0, 0, 1);
            }
            Collider2D coll = collision;
            coll.isTrigger = false;
            Player.Instance.transform.position = new Vector2(-50, -2f);
            for (int i = 0; i < colls.Length; i++)
            {
                colls[i].isTrigger = true;
            }
        }
    }
}
