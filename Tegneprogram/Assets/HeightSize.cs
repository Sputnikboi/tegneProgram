using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeightSize : MonoBehaviour
{   string text;
    public int height;
    //public TextMeshProUGUI  =?????
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        height = 700;
        //inputField = GameObject.Find("HeightInputField");
    }

    // Update is called once per frame
    public void EndEdit(){

        //text = inputField.GetComponent<m_Enabled>().text;
        height = int.Parse(inputField.text);
    }

}
