using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    private Camera cam; 
    bool Colorpicker = false;
    Vector3 pos;
    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {


    if(Colorpicker == true){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
             mousePos=Input.mousePosition;
             pos = cam.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 0));
            print(tex.GetPixel(pos[0], pos[1] , 0));
        }
    }

    }

    public void OnClickColorPicker(){
        Colorpicker = true;
    }
}
