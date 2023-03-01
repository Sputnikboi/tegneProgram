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
    int curPos = 0;
    bool drawing = false;
    GameObject lineRendererObj;
    GameObject circObj;
    LineRenderer lineRenderer;
    public Material mat1, mat2;
    int Order = 1;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        curPos=1;
        tegneProgram = mainCam.GetComponent<tegneProgram>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        prevMousePos =  cam.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 0));
        mousePos=Input.mousePosition;
        this.transform.position = cam.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 0));
        curPoint=cam.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 0));
        if(tegneProgram.tool == "pen"){

         if(Input.GetKey(KeyCode.Mouse0)&& drawing == false){
                lineRendererObj= Instantiate(obj,new Vector3(curPoint[0], curPoint[1],0),this.transform.rotation);
                lineRenderer=lineRendererObj.GetComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                lineRenderer.startColor = tegneProgram.color;
                lineRenderer.endColor = tegneProgram.color;
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
        } else if(tegneProgram.tool == "brush"){
            if(Input.GetKey(KeyCode.Mouse0)){
                circObj = Instantiate(brushSprite,new Vector3(curPoint[0],curPoint[1],0) ,this.transform.rotation);
                circObj.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
