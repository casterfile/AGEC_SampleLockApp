/*MIT License

Title: GameLuncher for Mobile

Copyright(c) 2020 Anthony Castor 

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppLauncherPlugin;
using UnityEngine.UI;
using System.IO;

public class LauncherApp : MonoBehaviour
{

    public string MobileAppID;//com.mobilemobility.agec sample name
    public string WindowAppID;//Name of the app

    public bool isFaceDetectSetting;
    public bool isFaceRecog;

    //private string rootURL = "192.168.254.83/download/";//192.168.254.83 //192.168.1.8
    public void TestOnMouseUp()
    {
        
        if (isFaceRecog == false)
        {

            //Script Located
            WebTextFileChecker textCheker = GameObject.Find("EventController").GetComponent<WebTextFileChecker>();
            //setText
#if UNITY_STANDALONE_WIN
            StartCoroutine(textCheker.SendToTheServerCurrentGame(WindowAppID));
#endif
#if UNITY_ANDROID
            StartCoroutine(textCheker.SendToTheServerCurrentGame(MobileAppID));
#endif
            //GetText
            StartCoroutine(textCheker.CheckToTheServerCurrentGame(WebTextFileChecker.rootURL + "samplePHP_Text_CurrentGame.txt"));


        }
        else
        {
            //Script Located
            WebTextFileChecker textCheker = GameObject.Find("EventController").GetComponent<WebTextFileChecker>();
            //setText
            StartCoroutine(textCheker.SendToTheServerFaceDetect("0"));

            //GetText
            StartCoroutine(textCheker.CheckToTheServerFaceDetect(WebTextFileChecker.rootURL + "samplePHP_Text_FaceDeteckLockApp.txt"));

        }


        WindowsAppLauncher();
        MobileAppLauncher();

    }
    public void WindowsAppLauncher()
    {
#if UNITY_STANDALONE_WIN
        //if (appDownloader.StartDownloadWindows(WindowAppID) == true)
        //{   
        //}
        if (isFaceDetectSetting == true)
        {
            HandleTextFile fileRead2 = new HandleTextFile();
            fileRead2.SetFileVariable("FaceDetectSetting", "0");
        }

        GameObject.Find("TextDebug").GetComponent<Text>().text = "Start Window App: " + WindowAppID;
        string m_Path = Application.dataPath;
        if (File.Exists(m_Path + "/../Library/" + WindowAppID + "/" + WindowAppID + ".exe") == true)
        {
            GameLuncher gl = new GameLuncher();
            gl.LunchNow(WindowAppID);

            HandleTextFile fileRead = new HandleTextFile();
            fileRead.SetFileVariable("GameName", WindowAppID);
        }
        else
        {
            downloadInstall.StartDownload();
        }

#endif
    }



    public void MobileAppLauncher()
    {
#if UNITY_ANDROID

        GameObject.Find("TextDebug").GetComponent<Text>().text = "Lunch App";
        AppLauncher.LaunchApp("" + MobileAppID, gameObject.name);

        



        if (AppLauncher.LaunchApp("" + MobileAppID, gameObject.name) == false)
        {
            GameObject.Find("TextDebug").GetComponent<Text>().text = "Download Start";
        }
        else
        {
            Application.Quit();
        }

#endif
    }



    

    /*
    private void Update()
    {
        print("this happen: "+ WebTextFileChecker.WebTextFileChecker_CurrentText);
    }
    */


}
