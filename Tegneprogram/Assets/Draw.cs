using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public PenTool PenTool;
    // Start is called before the first frame update
    void Start()
    {
        PenTool Pen = PenTool.GetComponent<PenTool>();
        Pen.OnClick.AddListener(OnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }

    void TaskOnClick(){
        print("hi");
    }
}
