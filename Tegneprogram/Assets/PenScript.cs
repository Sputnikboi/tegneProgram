using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenScript : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 curPoint;
    Vector3 prevMousePos;
    private Camera cam;
    public GameObject obj;
    public GameObject brushSprite;
    public GameObject mainCam;
    private tegneProgram tegneProgram;
    public int curPos = 0;
    public bool drawing = false;
    public GameObject lineRendererObj;
    GameObject circObj;
    public LineRenderer lineRenderer;
    public Material mat1, mat2;
    int Order = 1;
    // Start is called before the first frame update
    void Start() //finds the main camera and the tegneProgram script
    {
        cam = Camera.main;
        curPos=1;//Prepares the curPos variable for use during the pen tool
        tegneProgram = mainCam.GetComponent<tegneProgram>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        prevMousePos =  cam.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 0)); //gets the location of the cursor in the scene from the previous frame
        mousePos=Input.mousePosition; //get the current mouse position
        this.transform.position = cam.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 0)); //gets the location of the cursor in the scene and sets the position of the penController to that location
        curPoint=cam.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 0)); //gets the location of the cursor in the scene
        if(tegneProgram.tool == "pen"){ // checks if the current tool is the pen tool

         if(Input.GetKey(KeyCode.Mouse0)&& drawing == false){ //one first click of the mouse button, a lineRenderer object is instantiated and prepared
                lineRendererObj= Instantiate(obj,new Vector3(curPoint[0], curPoint[1],0),this.transform.rotation); //instantiates a lineRenderer object
                lineRenderer=lineRendererObj.GetComponent<LineRenderer>(); //gets the lineRenderer component from the lineRenderer object
                lineRenderer.material = new Material(Shader.Find("Sprites/Default")); //sets the material of the lineRenderer to the default sprite material
                lineRenderer.startColor = tegneProgram.color; //sets the color of the lineRenderer to the current color
                lineRenderer.endColor = tegneProgram.color; //sets the color of the lineRenderer to the current color
                lineRenderer.startWidth = tegneProgram.size; //sets the width of the lineRenderer to the current size
                lineRenderer.endWidth = tegneProgram.size; //sets the width of the lineRenderer to the current size
                lineRenderer.positionCount = 2; //sets the number of positions in the lineRenderer to 2
                lineRenderer.useWorldSpace = true; //sets the lineRenderer to use world space required for rendering
                lineRenderer.SetPosition(0, new Vector3(prevMousePos[0],prevMousePos[1],0)); //sets the starting x,y and z position of the line to the posistion of the cursor in the previous frame
                lineRenderer.SetPosition(1, new Vector3(curPoint[0],curPoint[1],0)); //sets the 2nd x,y and z position to the current position of the cursor
                drawing = true; //sets the drawing variable to true used to check if the user is still drawing or not
                lineRenderer.sortingOrder = Order;
                Order++;


            } else if(Input.GetKey(KeyCode.Mouse0) && drawing){


                lineRenderer.positionCount++;
                curPos++;
                lineRenderer.SetPosition(curPos, new Vector3(curPoint[0],curPoint[1],0));

            } else{ 
                lineRenderer= null;
                curPos =1;
                drawing = false;
            }
        } else if(tegneProgram.tool == "brush"){
            if(Input.GetKey(KeyCode.Mouse0)){
                circObj = Instantiate(brushSprite,new Vector3(curPoint[0],curPoint[1],0) ,this.transform.rotation);
                circObj.GetComponent<SpriteRenderer>().enabled = true;
            }
        } else if(tegneProgram.tool == "eraser"){
            if(Input.GetKey(KeyCode.Mouse0) && drawing == false){
                lineRendererObj= Instantiate(obj,new Vector3(curPoint[0], curPoint[1],0),this.transform.rotation);
                lineRenderer=lineRendererObj.GetComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                lineRenderer.startColor = new Vector4(1,1,1,1);
                lineRenderer.endColor = new Vector4(1,1,1,1);
                lineRenderer.startWidth = tegneProgram.size;
                lineRenderer.endWidth = tegneProgram.size;
                lineRenderer.positionCount = 2;
                lineRenderer.useWorldSpace = true;
                lineRenderer.SetPosition(0, new Vector3(prevMousePos[0],prevMousePos[1],0)); //x,y and z position of the starting point of the line
                lineRenderer.SetPosition(1, new Vector3(curPoint[0],curPoint[1],0));
                drawing = true;
                lineRenderer.sortingOrder = Order;
                Order++;
            } else if(Input.GetKey(KeyCode.Mouse0) && drawing){


                lineRenderer.positionCount++;
                curPos++;
                lineRenderer.SetPosition(curPos, new Vector3(curPoint[0],curPoint[1],0));

            } else{ 
                lineRenderer= null;
                curPos =1;
                drawing = false;
            }

        } else {
            lineRenderer= null;
            curPos =1;
            drawing = false;
        }
    }
}
