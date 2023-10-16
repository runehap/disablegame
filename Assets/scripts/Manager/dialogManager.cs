using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000,new string[] { "음?", "뭐야, 직사각형 처음봐?"});

        talkData.Add(100, new string[] { "오늘은 계단으로 가볼까?" });
        talkData.Add(200, new string[] { "엘리베이터로 가야지" });
    }

    public string GetTalk(int id,int talkIndex)
    {
        if(talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
            return talkData[id][talkIndex];
    }
}
