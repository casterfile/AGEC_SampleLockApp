using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripte : MonoBehaviour
{
    public GameObject HideObject;

    // Update is called once per frame
    void Update()
    {
        if(Global_GamePause.isPause == false)
        {
            //Some Other Script
            //HideObject.SetActive(true);
        }
        else
        {
            HideObject.SetActive(false);
        }
    }
}
