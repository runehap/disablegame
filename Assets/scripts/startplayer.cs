using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startplayer : MonoBehaviour
{
    [SerializeField]
    GameObject text;
    public float speed = 5f;
    Animator anim;
    bool ismove = false;
    GameObject target;
    GameManager gm;
    
    void Start()
    {
        target = GameObject.Find("stop");
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(ismove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }

        if(Input.GetKeyUp(KeyCode.A))
        {
            text.GetComponent<Text>().fontSize = 40;
            text.GetComponent<Text>().color = new Color32(255, 255, 255,255);
            anim.SetBool("isMove", true);
            ismove = true;
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            text.GetComponent<Text>().fontSize = 37;
            text.GetComponent<Text>().color = new Color32(200, 200, 200,255);
        }
    }
    //gm.GetComponent<GameManager>().Fadeout();
}
