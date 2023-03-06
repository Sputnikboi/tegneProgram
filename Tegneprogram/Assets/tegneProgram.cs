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
        width = GameObject.Find("WidthInputField");
        widthScript = width.GetComponent<WidthSize>();
        height = GameObject.Find("HeightInputField");
        heightScript = height.GetComponent<HeightSize>();
        pen = GameObject.Find("Pen Controller");
        penScript = pen.GetComponent<PenScript>();
        color = new Vector4(0,0,0,1);
        size = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPenTool(){
        tool = "pen";
        penScript.lineRenderer= null;
        penScript.curPos =1;
        penScript.drawing = false;
    }
    public void OnClickBrushTool(){
        tool = "brush";
    }
    public void OnClickEraserTool(){
        tool = "eraser";
        penScript.lineRenderer= null;
        penScript.curPos =1;
        penScript.drawing = false;
    }

    public void SubmitCanvas(){

        Instantiate(Canvas,new Vector3(0,-0.7f,0),transform.rotation);
        Instantiate(filler,new Vector3((float)(widthScript.width/200f)+10f,0,0),transform.rotation);
        Instantiate(filler,new Vector3(-1f*((float)widthScript.width/200f)-10f,0,0),transform.rotation);
        Instantiate(filler,new Vector3(0,(heightScript.height/200f)+4.3f,0),transform.rotation);
        print(heightScript.height/200f);
        Instantiate(filler,new Vector3(0,-1f*((float)heightScript.height/200f)-5.7f,0),transform.rotation);

        
    }
}
