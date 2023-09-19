using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startstop : MonoBehaviour
{
   [SerializeField]
   GameManager gm;
    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gm.GetComponent<GameManager>().Fadeout();
        }
    }
}
