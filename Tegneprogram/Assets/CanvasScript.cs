using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject heightObj;
    public GameObject widthObj;
    public GameObject Canvas;
    private HeightSize height;
    private WidthSize width;
    public GameObject[] UiElements;
    public GameObject pen;
    public GameObject StartPanel; 
    // Start is called before the first frame update
    void Start() //Setup when the canvas gets submitted
    {   
        pen=GameObject.Find("Pen Controller");  //finds the pen controller in the scene
        UiElements[0] = GameObject.Find("HeightInputField"); //finds the height input field ui element
        UiElements[1] = GameObject.Find("WidthInputField"); //finds the width input field ui element
        UiElements[2] = GameObject.Find("HeightText"); //finds the height text ui element
        UiElements[3] = GameObject.Find("WidthText"); //finds the width text ui element
        UiElements[4] = GameObject.Find("SubmitButton"); //finds the submit button ui element
        UiElements[5] = GameObject.Find("StartPanel"); //finds the start panel ui element
        UiElements[6] = GameObject.Find("StartBackground"); //finds the start background ui element
        height =UiElements[0].GetComponent<HeightSize>(); //gets the height size script from the height input field
        width = UiElements[1].GetComponent<WidthSize>(); //gets the width size script from the width input field
        transform.localScale = new Vector3(width.width/100,height.height/100,1); //sets the canvas size based on the previous submissions

        for(int i=0;i <7; i++){ //loops through the ui elements and disables/hides them
            UiElements[i].SetActive(false);
   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
