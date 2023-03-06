using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class colorwheel : MonoBehaviour
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
        loadTexture = new Texture2D(1,1);
 
        ColorWheel = GameObject.Find("ColorWheel");


        ColorWheel.SetActive(false);
        tegneProgram = GameObject.Find("Main Camera").GetComponent<tegneProgram>();
        color = tegneProgram.color;
        delay = 19948313;
    }

    // Update is called once per frame
    void Update()
    {


    if(Colorpicker == true){ //runs on mouseclick
    //frame delay
        if(Input.GetKeyDown(KeyCode.Mouse0)&& cooldown <0){
            ScreenCapture.CaptureScreenshot("IMG.png");
            path = "IMG.png";

            Colorpicker = false;
            delay = 5;
            
        }

    }

    cooldown--;
    delay--;
        if(delay <= 0){
            ColorWheel.SetActive(false);
            delay = 19948313;
            tegneProgram.tool = tempTool;
            bytes = File.ReadAllBytes(path);
            loadTexture.LoadImage(bytes);
            mousePos=Input.mousePosition;
            print(loadTexture.GetPixel((int)(mousePos[0]), (int)(mousePos[1]) , 0));
            tempVec = tegneProgram.color;
            tegneProgram.color = loadTexture.GetPixel((int)(mousePos[0]), (int)(mousePos[1]) , 0);
            tegneProgram.color[3] = tempVec[3];
            print(tegneProgram.color);
        }
    }

    public void OnClickColorWheel(){
        tempTool = tegneProgram.tool;
        
        tegneProgram.tool="colorwheel";

        ColorWheel.SetActive(true);

        print("here"); 

        Colorpicker = true;
        cooldown = 5;

    }

}
