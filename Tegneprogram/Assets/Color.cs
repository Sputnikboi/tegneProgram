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
    byte[] bytes;
    string path;
    Texture2D loadTexture; //mock size 1x1
    Sprite IMG;
    int cooldown;
    tegneProgram tegneProgram;
    Vector4 color;




    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        loadTexture = new Texture2D(1,1);
        tegneProgram = GameObject.Find("Main Camera").GetComponent<tegneProgram>();
        color = tegneProgram.color;
    }

    // Update is called once per frame
    void Update()
    {


    if(Colorpicker == true){ //runs on mouseclick
    //frame delay
        if(Input.GetKeyDown(KeyCode.Mouse0)&& cooldown <0){
             ScreenCapture.CaptureScreenshot("IMG.png");
             path = "IMG.png";
             bytes = File.ReadAllBytes(path);
             loadTexture.LoadImage(bytes);
             mousePos=Input.mousePosition;
             print(loadTexture.GetPixel((int)(mousePos[0]), (int)(mousePos[1]) , 0));
             tegneProgram.color = loadTexture.GetPixel((int)(mousePos[0]), (int)(mousePos[1]) , 0);
             print(tegneProgram.color);
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

