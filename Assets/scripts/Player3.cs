using System.Collections;
using System.Collections.Generic;
using Microsoft.Cci;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Player3 : MonoBehaviour
{
    [SerializeField]
    ObjData objda;
    public bool istriggerinter = false;
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
    public Image rb;
    public Image lb;
    public Image interbutton;
    void Start()
    {
        Application.targetFrameRate = 60;
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
            {
                sr.flipX = true;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                sr.flipX = false;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                lb.color = new Color(178 / 255f, 178 / 255f, 178 / 255f, 1);
            }
            else
            {
                lb.color = new Color(1.0f, 1.0f, 1.0f);
            }


            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.color = new Color(178 / 255f, 178 / 255f, 178 / 255f, 1);
            }
            else
            { 
                rb.color = new Color(1, 1, 1);
            }
            //else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            //{
            //   lb.color = new Color(1.0f, 1.0f, 1.0f);
            //}
            //else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            //{
            //    rb.color = new Color(1, 1, 1);
            //}

          



            // 움직이고있는지 멈춰있는지 판단
            if (rigid.velocity.normalized.x == 0)
                anim.SetBool("isMove", false);

            else
                anim.SetBool("isMove", true);

        }


        if (istrigger == true)
        {
            //if (Input.GetKeyDown(KeyCode.Return) && sc.isclick == false)
            //{
            //    sc.isclick = true;
            //    if (sc.CanUse == true)
            //    {
            //        gm.GetComponent<GameManager>().Fadeout();
            //        sc.Invoke("clickoff", 2);
            //    }
            //    else
            //    {
            //        sc.go.GetComponent<Text>().text = sc.cantUse;
            //        sc.go.gameObject.SetActive(true);

            //        sc.Invoke("setacoff", 2);
            //    }
            //}

            if(Input.GetButtonUp("Jump"))
            {
                talkmanger.Action(triggerob);
           
            }
            else if (Input.GetButton("Jump"))
            {
                interbutton.color = new Color(0.7f, 0.7f, 0.7f);
            }
            else
            {
                interbutton.color = new Color(1, 1, 1);
            }

        }

        if(istriggerinter == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
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
        objda = collision.GetComponent<ObjData>();
        if (collision.tag == "interactive")
        {
            istrigger = true;
            triggerob = collision.gameObject;
            sc = collision.GetComponent<sceneinteraction>();
            selpo = new Vector3(collision.transform.position.x, collision.transform.position.y + selpoy, collision.transform.position.z);
            GameObject sel = Instantiate(selectprefeb, selpo, transform.rotation);
            interbutton.enabled = true;

        }

        if(collision.tag == "triggerinter" && objda.isused == false)
        {
            triggerob = collision.gameObject;
            istriggerinter = true;
            talkmanger.Action(collision.gameObject);

            
        }

    }

   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "interactive")
        {
            istrigger = false;
            Destroy(GameObject.Find(selectprefeb.name + "(Clone)"));
            interbutton.enabled = false;

        }
    }

   
}
