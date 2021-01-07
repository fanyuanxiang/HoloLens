using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugType : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text t1=GameObject.Find("greenhouseName").GetComponent<Text>();
        Debug.Log(t1.text.ToString());
        Debug.Log("dkdklajfldkajfld this is text message !");
        t1.text = "change text greenhouse";
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
