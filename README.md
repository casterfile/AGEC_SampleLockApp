# AGEC_SampleLockApp
 Unity SampleLockApp allows your android application to be pause.
## Requirements
 Unity Editor 2019.4 or newer

## Installation
 This is for rehabilitation of the old people
 
## Usage
The following example demonstrates how to use the script:
```csharp
public class TestScripte : MonoBehaviour
{
    public GameObject HideObject;

    // Update is called once per frame
    void Update()
    {
        if(Global_GamePause.isPause == false)
        {
            //Some Other Script
            HideObject.SetActive(true);
        }
        else
        {
            HideObject.SetActive(false);
        }
    }
}
```

Using the Launcher: check the button for more info
```csharp
public class LauncherApp : MonoBehaviour
{
    public string MobileAppID;//com.mobilemobility.agec sample name
    public string WindowAppID;//Name of the app
    public bool isFaceRecog; // This button will be use for face recognition
	.
	..
	...
}
```



## License
This project is licensed under the terms of the [MIT License](https://opensource.org/licenses/MIT).
