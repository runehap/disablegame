using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    //Dictionary<int, Sprite> PorData;
    Dictionary<int, Sprite> myPorData;

    public Sprite[] porArr;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        //PorData = new Dictionary<int, Sprite>();
        myPorData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000,new string[] { "��?:100", "����, ���簢�� ó����?:100"});

        talkData.Add(100, new string[] { "������ ������� ������?:100" });
        talkData.Add(200, new string[] { "���������ͷ� ������:100" });

        //PorData.Add(1000 + 0, porArr[0]);
        myPorData.Add(0 + 0, porArr[0]);

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

    public Sprite GetPor(int id, int porIndex)
    {
        return myPorData[id + porIndex];
    }
}
