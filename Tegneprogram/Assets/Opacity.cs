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
        slider = GameObject.Find("OpacitySlider").GetComponent<Slider>();
        print(slider.value);
        MainCamera = GameObject.Find("Main Camera");
        tegneProgram = MainCamera.GetComponent<tegneProgram>();
        color = tegneProgram.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void opacity(){
        color = tegneProgram.color;
        color[3] = slider.value;
        print(color);
        tegneProgram.color = color;
    }
}
