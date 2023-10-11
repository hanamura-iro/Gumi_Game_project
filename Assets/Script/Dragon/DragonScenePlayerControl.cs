using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonScenePlayerControl : MonoBehaviour
{
    public static DragonScenePlayerControl Instance;
    Animator ani;
    public int movePower;
    private void Awake()
    {
        Instance = this;
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        if (!GameManager.Instance.isMenu)
        {
            Move();
            Run();
        }
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * movePower * Time.deltaTime;
            ani.SetBool("Walk", true);
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * movePower * Time.deltaTime;
            ani.SetBool("Walk", true);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            ani.SetBool("Walk", false);
        }
    }
    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movePower = 9;
        }
        else
        {
            movePower = 3;
        }
    }
}
