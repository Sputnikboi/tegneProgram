using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tegneProgram : MonoBehaviour
{
   public static string tool;
   public GameObject Canvas;
   public Vector4 color;
   public float size;
   


    // Start is called before the first frame update
    void Start()
    {
        color = new Vector4(0,0,0,1);
        size = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPenTool(){
        print("bitch");
        tool = "pen";
    }
    public void OnClickBrushTool(){
        tool = "brush";
    }

    public void SubmitCanvas(){

        Instantiate(Canvas,new Vector3(0,0,0),transform.rotation);

        
    }
}
