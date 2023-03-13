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
      Canvas = GameObject.Find("Canvas"); //locates "canvas" 
      print(Canvas); 
      name = "1.png"; //sets filename, path is local to file folder
      numb = 1; //variablen "numb" sættes til 1, og bruges senere
      delay = -1; //"delay" sættes til -1
    }

    // Update is called once per frame
    void Update()
    {
      if(delay > 0){ //når "PrintScreen()" har sat delay til 5, tæller denne ned
        delay--;
      }
      if(delay == 0){ //når "delay" = 0 sættes det igen til -1, og canvas aktiveres igen

        delay = -1;
        Canvas.SetActive(true);
      }
    }

    public void PrintScreen()
    {
      delay = 5; //"delay" sættes til 5 
      Canvas.SetActive(false); //canvas sættes til inaktiv
      ScreenCapture.CaptureScreenshot(name); //Screenshot tages og navngives med variablen "name"
      numb++; //numb tæller op for hvert screenshot
      name =  numb.ToString()+".png"; //de næste screenshot får nyt navn afhængigt af "numb"

    }
}
