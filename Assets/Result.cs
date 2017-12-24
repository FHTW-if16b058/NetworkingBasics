using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Result : NetworkBehaviour
{
	[SyncVar]
    public int _result;
    public InputField output;
    
    // Use this for initialization
    void Awake () {
        //var obj = GameObject.Find("InpResult");
        //output = obj.GetComponent<InputField>();
        //output.text = _result.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        //var obj = GameObject.Find("InpResult");
        //output = obj.GetComponent<InputField>();
        output.text = _result.ToString();
    }
}
