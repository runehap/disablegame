using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds;
    public GameObject EndCursor;

    AudioSource audioSource;
    string targetMsg;
    Text msgText;
    int index;
    float interval;
    bool isAnim;

    public void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        
    }
    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
        
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        interval = 1.0f / CharPerSeconds;
        Invoke("Effecting", interval);
    }
    
    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];

        // sound
        if(targetMsg[index] != ' ' || targetMsg[index] != '.' || targetMsg[index] != '?')
            audioSource.Play();

        index++;

        isAnim = true;
        Invoke("Effecting", interval);
    }

    void EffectEnd() {
        isAnim = false;
        EndCursor.SetActive(true);
    }


}
