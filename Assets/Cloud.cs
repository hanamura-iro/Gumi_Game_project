using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cloud : MonoBehaviour
{
    public float Speed = 0.5f;
    void Update()
    {
        transform.localPosition += Vector3.right * Speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("CloudEndPos"))
        {
            Debug.Log("Hit CloudEndPos");
            if(SceneManager.GetActiveScene().name == "MainScene")
                this.transform.position = new Vector2(-42,transform.position.y);
            if (SceneManager.GetActiveScene().name == "DragonCity")
                this.transform.position = new Vector2(-136f, transform.position.y);
        }
    }
}
