using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    
    public Transform target;
    [SerializeField]
    public float speed = 3f;
    public Vector3 targethead;
    [SerializeField]
    private float pluscamera = 1f;
    
    
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        targethead = new Vector3(target.position.x, target.position.y + pluscamera, target.position.z); 
    }

    void LateUpdate()
    {   
        //transform.position = new Vector3(target.position.x, target.position.y + pluscamera , -10f);
        transform.position = Vector3.Lerp(transform.position, targethead,Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
