using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSwitch : MonoBehaviour
{
    UnityEngine.UI.Button button;
    bool checkSwitch = true;
    private void Start()
    {
        button = GameObject.Find("JumpButton").GetComponent<UnityEngine.UI.Button>();
    }
    private void OnTriggerEnter()
    {
        if(checkSwitch)
        {
            Debug.Log("JUMPON");
            button.gameObject.SetActive(true);
            checkSwitch = true;
        }
        else
        {
            Debug.Log("JUMPOFF");
            button.gameObject.SetActive(false);
            checkSwitch = false;
        }
        
    }
}
