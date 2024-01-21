using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    static public int killcount;
    public Image myPorImg;
    public Image PorImg;

    public Animator anim;
    public startplayer stp;
    public ObjData objData;
    public GameManager gm;
    public Animator talkPanel;
    public Animator myporanim;
    public Animator poranim;
    public dialogManager dialog;
    public Player3 player;
    public TypeEffect talk;
    public GameObject scanObject;
    public bool isAction = true;
    public int talkIndex;
    string talkData = "";
    public int nextcode;
    public int nextcode2;
    public bool istimestop = false;
    public GameObject button;

  

    public void Action(GameObject scanObj)
    {

       
        isAction = true;
        button.SetActive(false);
        scanObject = scanObj;
        objData = scanObject.GetComponent<ObjData>();
        if(objData.isstair == false)
        {
            Talk(objData.id, objData.isNpc);
        }
        else
        {
            Talk(objData.id + killcount, objData.isNpc);
           
        }
        

        talkPanel.SetBool("isShow", isAction);
        if(isAction == false)
        {
            DoNext(nextcode);
            

        }

        
     
    }

    void Talk(int id,bool isNpc)
    {
        
        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
           talkData = dialog.GetTalk(id, talkIndex);
        }
        

        if(talkData == null)
        {
            if(objData.isstair == true)
            {
                killcount = 1;
            }
            player.istriggerinter = false;
            objData.isused = true;
            isAction = false;
            button.SetActive(true);
            talkIndex = 0;  
            return;
        }

        DoNext(int.Parse(talkData.Split(':')[3]));

        if (isNpc)
        {
            PorImg.enabled = true;
            myPorImg.color = new Color(142/255f, 142 / 255f, 142 / 255f, 1);
            PorImg.color = new Color(142 / 255f, 142 / 255f, 142 / 255f, 1);

            talk.SetMsg(talkData.Split(':')[0]);

            

            if (int.Parse(talkData.Split(':')[1]) >= 100)
            {
                myPorImg.sprite = dialog.GetPor(0, int.Parse(talkData.Split(':')[1])%100);
                myPorImg.color = new Color(1, 1, 1, 1);
                myporanim.SetTrigger("Doeffect");
            }
            else
            {
                PorImg.sprite = dialog.GetPor(id, int.Parse(talkData.Split(':')[1]));
                PorImg.color = new Color(1, 1, 1, 1);
                poranim.SetTrigger("Doeffect");

            }

            
        }
        else
        {
            talk.SetMsg(talkData.Split(':')[0]);

            if (int.Parse(talkData.Split(':')[1]) >= 100)
            {
                myPorImg.sprite = dialog.GetPor(0, int.Parse(talkData.Split(':')[1]) % 100);
            }

            PorImg.enabled = false;
            myPorImg.color = new Color(1, 1, 1, 1);
            myporanim.SetTrigger("Doeffect");
            
        }
       
        nextcode = int.Parse(talkData.Split(':')[2]);
        isAction = true;
        talkIndex++;
    }

    void DoNext(int NextBehaCode)
    {
        switch (NextBehaCode)
        {
            case 0:
                break;
            case 1:
                gm.nextscene = objData.nextscene;
                gm.Fadeout();
                break;
            case 2:
                istimestop = true;
                break;
            case 3:
                istimestop = false;
                break;
            case 4:
                stp.ismove = true;
                anim.SetBool("isMove", true);
                break;
        }
    }

   
}
