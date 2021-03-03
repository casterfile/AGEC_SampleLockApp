/*MIT License

Title: Web File Checker

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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WebTextFileChecker : MonoBehaviour
{
    public static string WebTextFileChecker_CurrentText = "";
    public static string WebTextFileChecker_FaceDetect = "";
    public static string rootURL = "192.168.254.83/download/";//192.168.254.83 //192.168.1.8

    public IEnumerator CheckToTheServerCurrentGame(string URL_TextFileRead)
    {
        WWW w = new WWW("http://"+ URL_TextFileRead);
        yield return w;
        if (w.error != null)
        {
            Debug.Log("Error .. " + w.error);
            // for example, often 'Error .. 404 Not Found'
        }
        else
        {
            Debug.Log("Found ... ==>" + w.text + "<==");
            WebTextFileChecker_CurrentText = w.text;
            print("222 WebTextFileChecker_CurrentText: " + WebTextFileChecker_CurrentText);
            // don't forget to look in the 'bottom section'
            // of Unity console to see the full text of
            // multiline console messages.
        }


    }

    public IEnumerator SendToTheServerCurrentGame(string currentGame)
    {
        string url = rootURL+"samplePHP_Text_CurrentGame.php?page=" + currentGame;
        using (WWW www = new WWW(url))
        {
            yield return www;
        }
    }

    public IEnumerator CheckToTheServerFaceDetect(string URL_TextFileRead)
    {
        WWW w = new WWW("http://" + URL_TextFileRead);
        yield return w;
        if (w.error != null)
        {
            Debug.Log("Error .. " + w.error);
            // for example, often 'Error .. 404 Not Found'
        }
        else
        {
            Debug.Log("Found ... ==>" + w.text + "<==");
            WebTextFileChecker_FaceDetect = w.text;
            print("222 WebTextFileChecker_CurrentText: " + WebTextFileChecker_FaceDetect);
            // don't forget to look in the 'bottom section'
            // of Unity console to see the full text of
            // multiline console messages.
        }


    }

    public IEnumerator SendToTheServerFaceDetect(string currentGame)
    {
        
        string url = rootURL + "samplePHP_Text_FaceDeteckLockApp.php?page=" + currentGame;
        using (WWW www = new WWW(url))
        {
            yield return www;
        }
    }
}