using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveImg : MonoBehaviour
{   
    string name;
    int numb;
    public GameObject Canvas;
    int delay;
    // Start is called before the first frame update
    void Start()
    {
      Canvas = GameObject.Find("Canvas");
      print(Canvas);
      name = "1.png";   
      numb = 1;
      delay = -1;
    }

    // Update is called once per frame
    void Update()
    {
      if(delay > 0){
        delay--;
      }
      if(delay == 0){

        delay = -1;
        Canvas.SetActive(true);
      }
    }

    public void PrintScreen()
    {
      
      delay = 5;
      Canvas.SetActive(false);
      ScreenCapture.CaptureScreenshot(name);
      numb++;
      name =  numb.ToString()+".png";

    }
}
