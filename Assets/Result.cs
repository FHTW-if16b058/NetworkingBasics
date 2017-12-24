using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Result : NetworkBehaviour                      // Grundlage für ResultObject
{
	[SyncVar]                                               // notwendig, damit das Ergebnis auf den Clients synchronisiert werden kann
    public int _result;
    public InputField output;
    
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //var obj = GameObject.Find("InpResult");
        //output = obj.GetComponent<InputField>();
        output.text = _result.ToString();                   // Verbindung zwischen Ergebnis und Output-Text
    }
}
