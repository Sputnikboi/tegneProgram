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
    GameObject ColorWheelicon;
    SpriteRenderer ColorWheel;
    tegneProgram tegneProgram;
    Vector4 color;
    int delay;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        loadTexture = new Texture2D(1,1);
 
        ColorWheelicon = GameObject.Find("ColorWheel");

        ColorWheel = ColorWheelicon.GetComponent<SpriteRenderer>();

        ColorWheel.enabled = false;
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
            delay = 5;
            
        }

    }

    cooldown--;
    delay--;
        if(delay <= 0){
            ColorWheel.enabled = false;
            delay = 19948313;
        }
    }

    public void OnClickColorWheel(){

        ColorWheel.enabled = true;

        print("here"); 

        Colorpicker = true;
        cooldown = 5;

    }

}
