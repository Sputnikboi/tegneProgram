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
    Vector4 tempVec;
    string tempTool;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        loadTexture = new Texture2D(1,1); //texture2D libray is used for "GetPixel" later
        tegneProgram = GameObject.Find("Main Camera").GetComponent<tegneProgram>(); //locates "tegneProgram" script
        color = tegneProgram.color; //sets the color in this class to the color from "tegneProgram"
    }

    // Update is called once per frame
    void Update()
    {


    if(Colorpicker == true){ //runs on mouseclick
    //frame delay
        if(Input.GetKeyDown(KeyCode.Mouse0)&& cooldown <0){ //cooldown ensures that program waits for new mouseclick
             ScreenCapture.CaptureScreenshot("IMG.png"); //screenshot
             path = "IMG.png"; //path in program folder
             bytes = File.ReadAllBytes(path); 
             loadTexture.LoadImage(bytes); //image is loaded from "bytes" as a texture
             mousePos=Input.mousePosition; //gets mouseposition
             print(loadTexture.GetPixel((int)(mousePos[0]), (int)(mousePos[1]) , 0)); //prints pixelcolor from mousePos on texture
            tempVec = tegneProgram.color; //temp for saving alpha value (opacity)
             tegneProgram.color = loadTexture.GetPixel((int)(mousePos[0]), (int)(mousePos[1]) , 0); //sets "master" color (tegneProgram.color) to pixelcolor value (including pixel alpha)
             tegneProgram.color[3] = tempVec[3]; //changes back alpha value to temp alpha value
             print(tegneProgram.color);
             Colorpicker = false; //sets colorpicker to false awaiting new click
             tegneProgram.tool = tempTool; //sets tool back to previous tool "tempTool"
        }
        cooldown--;
    }

    }

    public void OnClickColorPicker(){ //chooses colorpicker in program
        tempTool = tegneProgram.tool; //saves previous tool to "tempTool"
        
        tegneProgram.tool="colorpicker"; //sets "tegnProgram.tool" to "colorpicker" to prevent error when clicking a color
        Colorpicker = true; //sets Colorpicker to true, to run if-statement
        cooldown = 5;

    }

    
}

