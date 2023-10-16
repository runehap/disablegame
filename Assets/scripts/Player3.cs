using System.Collections;
using System.Collections.Generic;
using Microsoft.Cci;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Player3 : MonoBehaviour
{
    [SerializeField]
    private bool istrigger = false;
    public TalkManager talkmanger;
    public sceneinteraction sc;
    public GameManager gm;
    public GameObject triggerob;

    Vector2 inputvec;
    [SerializeField]
    public bool movelock = false;
    [SerializeField]
    float speed = 6f;

    //select button
    public GameObject selectprefeb;
    private Vector3 selpo;
    private float selpoy = 4f;
    // 텍스트 
    

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
        if(talkmanger.isAction)
        {
            inputvec.x = 0f;
            anim.SetBool("isMove", false);
            movelock = true;
        }
        else if(!talkmanger.isAction)
        {
            movelock = false;
        }

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


        if (istrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.Return) && sc.isclick == false)
            {
                sc.isclick = true;
                if (sc.CanUse == true)
                {
                    gm.GetComponent<GameManager>().Fadeout();
                    sc.Invoke("clickoff", 2);
                }
                else
                {
                    sc.go.GetComponent<Text>().text = sc.cantUse;
                    sc.go.gameObject.SetActive(true);

                    sc.Invoke("setacoff", 2);
                }
            }

            if(Input.GetButtonDown("Jump"))
            {
                talkmanger.Action(triggerob);
           
            }
            
        }
        

    }

    void FixedUpdate() {
        Vector2 nextvec = inputvec.normalized * speed;
        rigid.velocity = nextvec;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "interactive")
        {
            istrigger = true;
            triggerob = collision.gameObject;
            sc = collision.GetComponent<sceneinteraction>();
            selpo = new Vector3(collision.transform.position.x, collision.transform.position.y + selpoy, collision.transform.position.z);
            GameObject sel = Instantiate(selectprefeb, selpo, transform.rotation);
        }

    }

   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "interactive")
        {
            istrigger = false;
            Destroy(GameObject.Find(selectprefeb.name + "(Clone)"));

        }
    }

   
}
