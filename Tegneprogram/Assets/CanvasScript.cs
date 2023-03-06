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
    void Start()
    {   
        pen=GameObject.Find("Pen Controller");
        UiElements[0] = GameObject.Find("HeightInputField");
        UiElements[1] = GameObject.Find("WidthInputField");
        UiElements[2] = GameObject.Find("HeightText");
        UiElements[3] = GameObject.Find("WidthText");
        UiElements[4] = GameObject.Find("SubmitButton");
        UiElements[5] = GameObject.Find("StartPanel");
        UiElements[6] = GameObject.Find("StartBackground");
        height =UiElements[0].GetComponent<HeightSize>();
        width = UiElements[1].GetComponent<WidthSize>();
        transform.localScale = new Vector3(width.width/100,height.height/100,1);

        for(int i=0;i <7; i++){
            UiElements[i].SetActive(false);
   
        }
        pen.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
