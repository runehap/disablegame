using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sceneinteraction : MonoBehaviour
{
    private Rigidbody2D rg;
    private bool istrigger = false;
    private bool isclick = false;
    [SerializeField]
    //�ؽ�Ʈ
    private string cantUse = "��ü��� �ش� �ü��� �̿��� �� �����ϴ�.";
    [SerializeField]
    private bool CanUse = true;
    public GameObject go;
    //gamemanager
    [SerializeField]
    private GameManager gm;
    // ���� ��ư
    public GameObject selectprefeb;
    private Vector3 selpo;
    private float selpoy = 4f;


    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        selpo = new Vector3(transform.position.x, transform.position.y +selpoy, transform.position.z);
        
    }

    private void Update()
    {
        if(istrigger == true)
        {

            if (Input.GetKeyDown(KeyCode.Return) && isclick == false)
            {
                isclick = true;
                if (CanUse == true)
                {
                    gm.GetComponent<GameManager>().Fadeout();
                    Invoke("clickoff", 2);
                }
                else
                {
                    go.GetComponent<Text>().text = cantUse;
                    go.gameObject.SetActive(true);

                    Invoke("setacoff", 2);
                }
                
            }
        }
    }
    void clickoff()
    {
        isclick = false;
    }
    void setacoff()
    {
        go.gameObject.SetActive(false);
        isclick = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            istrigger = true;
            GameObject sel = Instantiate(selectprefeb,selpo, transform.rotation);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
       
        if (other.tag == "Player")
        {
            istrigger = false;
            Destroy(GameObject.Find(selectprefeb.name + "(Clone)"));
        }
    }
}

