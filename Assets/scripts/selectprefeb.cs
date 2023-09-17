using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectprefeb : MonoBehaviour
{
    [SerializeField]
    Vector3 pos;
    private float delta = 0.3f;
    private float speed = 5.0f;
    

    void Start()
    {
        pos = transform.position;
    }

    
    void Update()
    {
        Vector3 v = pos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
