using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public Image myPorImg;

    public dialogManager dialog;
    public Player3 player;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction = true;
    public int talkIndex;
    
    public void Action(GameObject scanObj)
    {
        
        
        isAction = true;
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);
        
        talkPanel.SetActive(isAction);
    }

    void Talk(int id,bool isNpc)
    {
        string talkData = dialog.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        if(isNpc)
        {
            talkText.text = talkData.Split(':')[0];
           
            if(int.Parse(talkData.Split(':')[1]) >= 100)
            {
                myPorImg.sprite = dialog.GetPor(0, int.Parse(talkData.Split(':')[1])%100);
            }
            else
            {
                myPorImg.sprite = dialog.GetPor(id, int.Parse(talkData.Split(':')[1]));
            }

            myPorImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData.Split(':')[0];

            if (int.Parse(talkData.Split(':')[1]) >= 100)
            {
                myPorImg.sprite = dialog.GetPor(0, int.Parse(talkData.Split(':')[1]) % 100);
            }
           


            myPorImg.color = new Color(1, 1, 1, 1);
        }
        isAction = true;
        talkIndex++;
    }
}
