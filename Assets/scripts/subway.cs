using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subway : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    GameObject stop;
    float curentTime = 1f;
    public float smoothtime = 0.2f;
    [SerializeField]
    //private float subwayspeed = 0.1f;

    void Start()
    {
        anim = GetComponent<Animator>();
        stop = GameObject.Find("stop3");
    }

    
    void Update()
    {
        Vector3 velo = Vector3.zero;

        curentTime -= Time.deltaTime/4;
        if(curentTime <= smoothtime)
        {
            curentTime = smoothtime;
        }
        transform.position = Vector3.SmoothDamp(transform.position, stop.transform.position,ref velo,curentTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "stop1")
        {
            anim.SetBool("isdooropen", true);
            Invoke("doorclose", 5);
        }
        else if (collision.name == "stop2")
        {
            Invoke("stop3", 3);
        }
        else if(collision.name == "stop3")
        {
            Invoke("stop1", 3);
        }
    }
    void doorclose()
    {
        anim.SetBool("isdooropen", false);
        Invoke("stop2", 3);
    }
    void stop2()
    {
        stop = GameObject.Find("stop2");
        curentTime = 1f;
    }
    void stop3()
    {
        transform.position = new Vector3(290f, 0, 0);
        stop = GameObject.Find("stop3");
        curentTime = 1f;
    }
    void stop1()
    {
        stop = GameObject.Find("stop1");
        curentTime = 1f;
    }
}
