using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    Animator ani;
    SpriteRenderer render;

    public int movePower = 1;
    public int jumpPower = 1;
    private void Awake()
    {
        Instance = this;

        ani = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Move();
        Run();
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * movePower * Time.deltaTime;
            ani.SetBool("Walk",true);
            render.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * movePower * Time.deltaTime;
            render.flipX = false;
            ani.SetBool("Walk", true);
        }
        else 
        {
            ani.SetBool("Walk", false);
        }
    }
    void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            movePower = 9;
        }
        else
        {
            movePower = 3;
        }
    }

}
