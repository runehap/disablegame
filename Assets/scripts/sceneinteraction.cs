using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sceneinteraction : MonoBehaviour
{
  
    public bool isclick = false;
    [SerializeField]
    //�ؽ�Ʈ
    public string cantUse = "��ü��� �ش� �ü��� �̿��� �� �����ϴ�.";
    [SerializeField]
    public bool CanUse = true;
    public GameObject go;
    //gamemanager
    [SerializeField]
    private GameManager gm;
    // ���� ��ư
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

