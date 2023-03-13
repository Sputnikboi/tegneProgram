using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opacity : MonoBehaviour
{   
    GameObject MainCamera;
    public Slider slider;
    tegneProgram tegneProgram;
    Vector4 color;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("OpacitySlider").GetComponent<Slider>(); //locates OpacitySlider using GetComponent
        print(slider.value);
        MainCamera = GameObject.Find("Main Camera"); 
        tegneProgram = MainCamera.GetComponent<tegneProgram>(); //locates "tegneProgram" script
        color = tegneProgram.color; //"color" is set to "tegneProgram.color" 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void opacity(){
        color = tegneProgram.color; //"color" is set to "tegneProgram.color" 
        color[3] = slider.value; //alpha value in "color" is set to slider value
        print(color);
        tegneProgram.color = color; //"tegneProgram.color" is set to new "color" including alpha value
    }
}
