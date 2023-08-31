using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int movePower = 1;
    public int jumpPower = 1;

    Rigidbody2D rigid;
    Animator ani;
    SpriteRenderer render;

    bool isJumping = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            Jump();
        }
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            moveVelocity = Vector3.left;
            ani.SetBool("Walk",true);
            render.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveVelocity = Vector3.right;
            render.flipX = false;
            ani.SetBool("Walk", true);
        }
        else 
        {
            ani.SetBool("Walk", false);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Jump()
    {
        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
}
