using System.Collections;
using System.Collections.Generic;
using Microsoft.Cci;
using UnityEditor;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    Vector2 inputvec;
    [SerializeField]
    bool movelock = false;
    [SerializeField]
    float speed = 6f;
    
    Rigidbody2D rigid;
    SpriteRenderer sr;
    Animator anim;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (movelock == false)
        {
            inputvec.x = Input.GetAxisRaw("Horizontal");

            // 방향전환
            if (Input.GetAxisRaw("Horizontal") < 0)
                sr.flipX = true;
            else if (Input.GetAxisRaw("Horizontal") > 0)
                sr.flipX = false;



            // 움직이고있는지 멈춰있는지 판단
            if (rigid.velocity.normalized.x == 0)
                anim.SetBool("isMove", false);

            else
                anim.SetBool("isMove", true);
        }
    }

    void FixedUpdate() {
        Vector2 nextvec = inputvec.normalized * speed;
        rigid.velocity = nextvec;
    }
}
