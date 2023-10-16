using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sceneinteraction : MonoBehaviour
{
  
    public bool isclick = false;
    [SerializeField]
    //텍스트
    public string cantUse = "휠체어는 해당 시설을 이용할 수 없습니다.";
    [SerializeField]
    public bool CanUse = true;
    public GameObject go;
    //gamemanager
    [SerializeField]
    private GameManager gm;
    // 선택 버튼
    public GameObject selectprefeb;
    
    
    void clickoff()
    {
        isclick = false;
    }
    void setacoff()
    {
        go.gameObject.SetActive(false);
        isclick = false;
    }
   
}

