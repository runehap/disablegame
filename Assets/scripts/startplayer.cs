using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startplayer : MonoBehaviour
{
    [SerializeField]
    AudioSource ad;
    public bool issoundplay = false;
    public bool isstart = false;
    public TalkManager tm;
    public  GameObject text;
    public ObjData obda;
    public float speed = 5f;
    public Animator anim;
    public bool ismove = false;
    GameObject target;
    GameManager gm;
    
    void Start()
    {
        target = GameObject.Find("stop");
        anim = GetComponent<Animator>();
        obda = text.GetComponent<ObjData>();
        ad = GetComponent<AudioSource>();
       
    }

    
    void Update()
    {
        if(ismove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.Space) && obda.isused == false)
        {
            if (isstart == true)
            {
                tm.Action(text);
            }
            else if(isstart == false && issoundplay == false)
            {
                text.GetComponent<Text>().fontSize = 40;
                text.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
                text.SetActive(false);
                ad.Play();
                issoundplay = true;
                Invoke("soundplay", 4.2f);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            text.GetComponent<Text>().fontSize = 37;
            text.GetComponent<Text>().color = new Color32(200, 200, 200,255);
        }
    }

    void soundplay()
    {
        isstart = true;
        tm.Action(text);
    }
    //gm.GetComponent<GameManager>().Fadeout();
}
