using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScale : MonoBehaviour
{
    GameObject MainCamera;
    public Slider slider;
    tegneProgram tegneProgram;
    Vector4 color;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("BrushSlider").GetComponent<Slider>(); //BrusgSlider lokaliseres via GetComponent
        print(slider.value);
        MainCamera = GameObject.Find("Main Camera");
        tegneProgram = MainCamera.GetComponent<tegneProgram>(); //"tegneProgram" script lokaliseres
        color = tegneProgram.color; //"color" sættes til "tegneProgram.color"
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSize(){
        tegneProgram.size = slider.value; //"tegneProgram.size" sættes til "slider.value", styrer størrelse på tools
    }
}
