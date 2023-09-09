using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newalbedo : AlbedoController
{
    [SerializeField]
    public SpriteRenderer ansr;

    private void Start()
    {
        ansr = GameObject.Find("stick").GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Color color2 = new Color(ansr.color.r, ansr.color.g, ansr.color.b, albedo);
        ansr.color = Color.Lerp(ansr.color, color2, Time.deltaTime * albedospeed);
    }
}
