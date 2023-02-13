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
    public GameObject circ;
    int curPos = 0;
    GameObject lineRendererObj;
    GameObject circObj;
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        curPos=1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        prevMousePos =  cam.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 0));
        mousePos=Input.mousePosition;
        this.transform.position = cam.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 0));
        curPoint=cam.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 0));
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Instantiate(obj,this.transform.position,this.transform.rotation);
            lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
            //circObj = Instantiate(circ,curPoint,this.transform.rotation);
            lineRendererObj= Instantiate(obj,this.transform.position,this.transform.rotation);

            lineRenderer=lineRendererObj.GetComponent<LineRenderer>();
            lineRenderer.startColor = Color.black;
            lineRenderer.endColor = Color.black;
            lineRenderer.startWidth = 0.20f;
            lineRenderer.endWidth = 0.20f;
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
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
    }
}
