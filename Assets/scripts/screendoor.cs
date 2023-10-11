using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screendoor : MonoBehaviour
{
    Animator anim;
    BoxCollider2D bc;
    GameObject obj;
    void Start()
    {
        anim = GetComponent<Animator>();
        obj = GameObject.Find("subway");
        bc = GetComponent<BoxCollider2D>();
    }

    
    void FixedUpdate()
    {
         if(obj.GetComponent<subway>().isdooropen == true)
        {
            bc.enabled = true;
            anim.SetBool("issdopen", true);
        }
        else
        {
            bc.enabled = false;
            anim.SetBool("issdopen", false);
        }
    }
}
