using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WidthSize : MonoBehaviour
{   string text;
    public int width;
    //public TextMeshProUGUI  =?????
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        //inputField = GameObject.Find("HeightInputField");
    }

    // Update is called once per frame
    public void EndEdit(){

        //text = inputField.GetComponent<m_Enabled>().text;
        width = int.Parse(inputField.text);
        print(width);
    }
}
