using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sceneinteraction : MonoBehaviour
{
    private Rigidbody2D rg;
    [SerializeField]
    private GameManager gm;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                gm.GetComponent<GameManager>().Fadeout();
            }
        }
    }
}
