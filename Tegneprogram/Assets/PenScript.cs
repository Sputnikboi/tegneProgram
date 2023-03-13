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
                lineRenderer.sortingOrder = Order;//orders new lines on top of old lines
                Order++; //increases the order variable so that new lines are always on top of old lines


            } else if(Input.GetKey(KeyCode.Mouse0) && drawing){ //if the user is still drawing, the lineRenderer object is updated with the new position of the cursor


                lineRenderer.positionCount++; //increases the number of positions in the lineRenderer by 1
                curPos++; //increases the curPos variable by 1 so the linjeRenderer knows where to place the next position
                lineRenderer.SetPosition(curPos, new Vector3(curPoint[0],curPoint[1],0)); //sets the next position of the lineRenderer to the current position of the cursor

            } else{ //if the user stops drawing the current lineRenderer is reset to prepare for the next line
                lineRenderer= null; //resets the lineRenderer variable
                curPos =1; //resets the curPos variable
                drawing = false; //resets the drawing variable
            }
        } else if(tegneProgram.tool == "brush"){ //checks if the current tool is the brush tool
            if(Input.GetKey(KeyCode.Mouse0)){ //if the user is holding down the mouse button, a brush sprite is instantiated at the current position of the cursor
                circObj = Instantiate(brushSprite,new Vector3(curPoint[0],curPoint[1],0) ,this.transform.rotation); //instantiates a brush sprite
                circObj.GetComponent<SpriteRenderer>().enabled = true; //enables the spriteRenderer component of the brush sprite
            }
        } else if(tegneProgram.tool == "eraser"){ //checks if the current tool is the eraser tool
            if(Input.GetKey(KeyCode.Mouse0) && drawing == false){ //uses the same code as the pen tool to draw a lineRenderer object thats always white instead of the current color
                lineRendererObj= Instantiate(obj,new Vector3(curPoint[0], curPoint[1],0),this.transform.rotation); //instantiates a lineRenderer object
                lineRenderer=lineRendererObj.GetComponent<LineRenderer>(); //targets the lineRenderer component of the lineRenderer object
                lineRenderer.material = new Material(Shader.Find("Sprites/Default")); //sets the material of the lineRenderer to the default sprite material
                lineRenderer.startColor = new Vector4(1,1,1,1); //sets the color of the lineRenderer to white
                lineRenderer.endColor = new Vector4(1,1,1,1); //sets the color of the lineRenderer to white
                lineRenderer.startWidth = tegneProgram.size; //sets the width of the lineRenderer to the current size
                lineRenderer.endWidth = tegneProgram.size; //sets the width of the lineRenderer to the current size
                lineRenderer.positionCount = 2;//sets the number of positions in the lineRenderer to 2
                lineRenderer.useWorldSpace = true; //sets the lineRenderer to use world space required for rendering
                lineRenderer.SetPosition(0, new Vector3(prevMousePos[0],prevMousePos[1],0)); //sets the starting x,y and z position of the line to the posistion of the cursor in the previous frame
                lineRenderer.SetPosition(1, new Vector3(curPoint[0],curPoint[1],0)); //sets the 2nd x,y and z position to the current position of the cursor
                drawing = true; //sets the drawing variable to true used to check if the user is still drawing or not
                lineRenderer.sortingOrder = Order; //orders new lines on top of old lines
                Order++; //increases the order variable so that new lines are always on top of old lines
            } else if(Input.GetKey(KeyCode.Mouse0) && drawing){ //same as the pen tool 

                lineRenderer.positionCount++;
                curPos++;
                lineRenderer.SetPosition(curPos, new Vector3(curPoint[0],curPoint[1],0));

            } else{ //same as the pen tool aka clears the lineRenderer and resets the drawing variables
                lineRenderer= null;
                curPos =1;
                drawing = false;
            }

        } else { //if all else fails, the lineRenderer is cleared and the drawing variables are reset to prevent weird drawing lines when switching tools
            lineRenderer= null;
            curPos =1;
            drawing = false;
        }
    }
}
