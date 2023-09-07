using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbedoController : MonoBehaviour
{
    private Rigidbody2D eleri;
    private SpriteRenderer elesr;
    public float albedo = 1f;
    [SerializeField]
    public float albedospeed = 0.5f;

    void Start()
    {
        eleri = GetComponent<Rigidbody2D>();
        elesr = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            albedo -= 0.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            albedo += 0.5f;
        }
    }


    private void FixedUpdate()
    {
        Color color = new Color(elesr.color.r, elesr.color.g, elesr.color.b, albedo);
        elesr.color = Color.Lerp(elesr.color, color, Time.deltaTime * albedospeed);
    }
}
