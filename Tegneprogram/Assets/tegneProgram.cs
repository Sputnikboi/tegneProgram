using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tegneProgram : MonoBehaviour
{
   public string tool;
   public GameObject Canvas;
   public Vector4 color;
   public float size;
   GameObject pen;
   PenScript penScript;
   public GameObject filler;
   GameObject height;
   HeightSize heightScript;
   GameObject width;
   WidthSize widthScript;
   


    // Start is called before the first frame update
    void Start()
    {
        width = GameObject.Find("WidthInputField"); //finds the width input field ui element
        widthScript = width.GetComponent<WidthSize>(); //gets the width size script from the width input field
        height = GameObject.Find("HeightInputField"); //finds the height input field ui element
        heightScript = height.GetComponent<HeightSize>(); //gets the height size script from the height input field
        pen = GameObject.Find("Pen Controller"); //finds the pen controller in the scene
        penScript = pen.GetComponent<PenScript>(); //gets the pen script from the pen controller
        color = new Vector4(0,0,0,1); //sets the default color to black with full opacity
        size = 0.2f; //sets the default brushsize to 0.2
    }

    public void OnClickPenTool(){ //sets the tool to pen and prepares the pen for drawing
        tool = "pen";
        penScript.lineRenderer= null; //clears the current lineRenderer
        penScript.curPos =1;
        penScript.drawing = false; //disables drawing for one frame to prevent missdraws
    }
    public void OnClickBrushTool(){ //sets the tool to brush
        tool = "brush";
    }
    public void OnClickEraserTool(){ //sets the tool to eraser and prepares the eraser for drawing
        tool = "eraser";
        penScript.lineRenderer= null; //clears the current lineRenderer
        penScript.curPos =1;
        penScript.drawing = false; //disables drawing for one frame to prevent missdraws
    }

    public void SubmitCanvas(){ //generates and prepares the canvas for drawing

        Instantiate(Canvas,new Vector3(0,-0.7f,0),transform.rotation); //instantiates the canvas at the correct position
        Instantiate(filler,new Vector3((float)(widthScript.width/200f)+10f,0,0),transform.rotation); //instantiates the fillers at the correct positions based on the submitted canvas size 
        Instantiate(filler,new Vector3(-1f*((float)widthScript.width/200f)-10f,0,0),transform.rotation);
        Instantiate(filler,new Vector3(0,(heightScript.height/200f)+4.3f,0),transform.rotation);
        print(heightScript.height/200f);
        Instantiate(filler,new Vector3(0,-1f*((float)heightScript.height/200f)-5.7f,0),transform.rotation);

        
    }
}
