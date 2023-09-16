using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public string nextscene = "substation1";
    public Image panel;
    public bool isfadout = false;
    [SerializeField]
    float time = 0f;
    float F_time = 1f;

    private void Start()
    {
        Fadein();
    }



    public void Fadeout()
    {
        StartCoroutine(FadeoutFlow());
    }
    public void Fadein()
    {
        StartCoroutine(FadeinFlow());
    }

    IEnumerator FadeinFlow()
    {

        panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = panel.color;
        yield return new WaitForSeconds(1f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            panel.color = alpha;
            yield return null;
        }
        panel.gameObject.SetActive(false);
        yield return null;
    }


    IEnumerator FadeoutFlow()
    {
        panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            panel.color = alpha;
            yield return null;
        }
        time = 0f;
        SceneManager.LoadScene(nextscene);
        yield return new WaitForSeconds(1f);

    }
    
   
   
   
    
    
}
