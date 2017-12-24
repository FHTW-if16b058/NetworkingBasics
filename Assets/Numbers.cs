using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Numbers : NetworkBehaviour                     // Grundlage für NumbersObject
{
    //[SyncVar]                                             // bei SyncList nicht notwendig
    public SyncListInt _playerNumbers = new SyncListInt();

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
