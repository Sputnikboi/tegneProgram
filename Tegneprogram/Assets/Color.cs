using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Color : MonoBehaviour
{
    private Camera cam; 
    bool Colorpicker = false;
    Vector3 pos;
    Vector3 mousePos;
    GameObject canvas;
    byte[] bytes;
    string path;
    Texture2D loadTexture; //mock size 1x1
    Sprite IMG;
    int cooldown;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        loadTexture = new Texture2D(1,1);
    }

    // Update is called once per frame
    void Update()
    {


    if(Colorpicker == true){ //runs on mouseclick
    //frame delay
        if(Input.GetKeyDown(KeyCode.Mouse0)&& cooldown <0){
             ScreenCapture.CaptureScreenshot("IMG.png");
             path = "C:/Users/linax/OneDrive/Dokumenter/GitHub/tegneProgram/Tegneprogram/IMG.png";
             bytes = File.ReadAllBytes(path);
             loadTexture.LoadImage(bytes);
             mousePos=Input.mousePosition;
             print(loadTexture.GetPixel((int)(mousePos[0]), (int)(mousePos[1]) , 0));
             Colorpicker = false;
        }
        cooldown--;
    }

    }

    public void OnClickColorPicker(){ //chooses colorpicker in program
        Colorpicker = true;
        cooldown = 5;

    }

    
}

