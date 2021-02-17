# AGEC_SampleLockApp
 Unity Android Files Opener allows your android application to open files on local drive with (**including API Level 24 or higher**).
 If you encounter a problem on Android Application.OpenUrl does not work, then this will solve your problem!

## Requirements
 Unity Editor 2019.4 or newer

## Installation
 This is for rehabilitation of the old people
 
## Usage
The following example demonstrates how to open a file:
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

## License
This project is licensed under the terms of the [MIT License](https://opensource.org/licenses/MIT).
