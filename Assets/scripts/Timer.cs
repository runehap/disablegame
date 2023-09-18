using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI

public class Timer : MonoBehaviour
{
    [SerializeField]
    public float limittime = 100f;
    private GameObject time;

    void start()
    {
        time = GetComponent<Text>();
    }
    void Update()
    {
        limittime -= Time.deltaTime;
        time.text = "제한시간 : " + Mathf.Round(limittime);
    }
}