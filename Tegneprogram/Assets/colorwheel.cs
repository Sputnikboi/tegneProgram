using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class colorwheel : MonoBehaviour
{
    private Camera cam; 
    bool Colorwheel = false;
    Vector3 pos;
    Vector3 mousePos;
    GameObject canvas;
    byte[] bytes;
    string path;
    Texture2D loadTexture; //mock size 1x1
    Sprite IMG;
    int cooldown;
    GameObject ColorWheel;
    tegneProgram tegneProgram;
    Vector4 color;
    int delay;
    Vector4 tempVec;
    string tempTool;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        loadTexture = new Texture2D(1,1); //texture2D library is used for GetPixel later
 
        ColorWheel = GameObject.Find("ColorWheel"); //locates ColorWheel image
        ColorWheel.SetActive(false); //sets Image to inactive

        tegneProgram = GameObject.Find("Main Camera").GetComponent<tegneProgram>(); //locates "tegneProgram" script
        color = tegneProgram.color; //sets "color" to "tegneProgram.color"
        delay = 19948313;
    }

    // Update is called once per frame
    void Update()
    {


    if(Colorwheel == true){ //runs on mouseclick
    //frame delay
        if(Input.GetKeyDown(KeyCode.Mouse0)&& cooldown <0){ //cooldown ensures that program waits for new mouseclick
            ScreenCapture.CaptureScreenshot("IMG.png"); //takes screenshot
            path = "IMG.png"; //filepath from program folder

            Colorwheel = false; //colorwheel is set to false awaiting new activation
            delay = 5; //delay to ensure that screenshot is taken before the rest of the code runs
            
        }

    }

    cooldown--; 
    delay--; 
        if(delay <= 0){
            ColorWheel.SetActive(false); //sets "colorWheel" to inactive
            delay = 19948313;
            tegneProgram.tool = tempTool; //"tegneProgram.tool" is set to "tempTool" to save previous tool
            bytes = File.ReadAllBytes(path);
            loadTexture.LoadImage(bytes); //images is loaded from "bytes" as a texture
            mousePos=Input.mousePosition; //gets mouseposition
            print(loadTexture.GetPixel((int)(mousePos[0]), (int)(mousePos[1]) , 0)); //prints pixelcolor from mouseposition on texture (image)
            tempVec = tegneProgram.color; //tempVec to save alpha value from pixel color
            tegneProgram.color = loadTexture.GetPixel((int)(mousePos[0]), (int)(mousePos[1]) , 0); //sets "tegneProgram.color" to pixelcolor from mouseposition on image
            tegneProgram.color[3] = tempVec[3]; //sets alpha value back to saved alpha value (opacity) in "tempVec"
            print(tegneProgram.color);
        }
    }

    public void OnClickColorWheel(){
        tempTool = tegneProgram.tool; //sets "tempTool" to "tegneProgram.tool"
        
        tegneProgram.tool="colorwheel"; //sets "tegnProgram.tool" to "colorwheel" to prevent error when clicking a color

        ColorWheel.SetActive(true); //sets ColorWheel as inactive

        Colorwheel = true; //Colorwheel is set to true, so rest of the code runs
        cooldown = 5; //cooldown to wait for colorwheel to appear

    }

}
