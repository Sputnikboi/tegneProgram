using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveImg : MonoBehaviour
{   
    string name;
    int numb;
    // Start is called before the first frame update
    void Start()
    {
      name = "1.png";   
      numb = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrintScreen()
    {
        ScreenCapture.CaptureScreenshot(name);
        numb++;
        name =  numb.ToString()+".png";
        print("hi");
    }
}
