using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screendoor : MonoBehaviour
{
    Animator anim;
    GameObject obj;
    void Start()
    {
        anim = GetComponent<Animator>();
        obj = GameObject.Find("subway");
    }

    
    void FixedUpdate()
    {
         if(obj.GetComponent<subway>().isdooropen == true)
        {
            anim.SetBool("issdopen", true);
        }
        else
        {
            anim.SetBool("issdopen", false);
        }
    }
}
