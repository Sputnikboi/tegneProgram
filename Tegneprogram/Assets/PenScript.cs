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
    GameObject lineRendererObj;
    GameObject circObj;
    LineRenderer lineRenderer;
    public Material mat1, mat2;
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
            if(Input.GetKeyDown(KeyCode.Mouse0)){

                lineRendererObj= Instantiate(obj,new Vector3(curPoint[0], curPoint[1],0),this.transform.rotation);
                lineRenderer=lineRendererObj.GetComponent<LineRenderer>();
                lineRenderer.startColor = Color.black;
                lineRenderer.endColor = Color.black;
                lineRenderer.startWidth = 0.20f;
                lineRenderer.endWidth = 0.20f;
                lineRenderer.positionCount = 2;
                lineRenderer.useWorldSpace = true;
                lineRenderer.material = mat1;
                lineRenderer.SetPosition(0, new Vector3(prevMousePos[0],prevMousePos[1],0)); //x,y and z position of the starting point of the line
                lineRenderer.SetPosition(1, new Vector3(curPoint[0],curPoint[1],0));
            } else if(Input.GetKey(KeyCode.Mouse0)){
                lineRenderer.positionCount++;
                curPos++;
                lineRenderer.SetPosition(curPos, new Vector3(curPoint[0],curPoint[1],0));
                
            } else{
                lineRenderer= null;
                curPos =1;
            }
        } else if(tegneProgram.tool == "brush"){
            if(Input.GetKey(KeyCode.Mouse0)){
                circObj = Instantiate(brushSprite,new Vector3(curPoint[0],curPoint[1],0) ,this.transform.rotation);
                circObj.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
