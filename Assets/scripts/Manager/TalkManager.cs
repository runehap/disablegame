using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
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
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }
        isAction = true;
        talkIndex++;
    }
}
