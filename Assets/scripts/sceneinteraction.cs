using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneinteraction : MonoBehaviour
{
    [SerializeField]
    private string nextscene = "substation1";
    private Rigidbody2D rg;
    
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
                SceneManager.LoadScene(nextscene);
            }
        }
    }
}
