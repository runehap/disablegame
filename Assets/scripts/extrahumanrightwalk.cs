using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extrahumanrightwalk : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D huri;
    void Start()
    {
        huri = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "system")
        {
            Destroy(gameObject);
        }
    }


    void FixedUpdate()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
}
