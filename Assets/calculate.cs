using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;


public class calculate : NetworkBehaviour {

    private int _number;
    private InputField InpNumber;
    private InputField InpResult;
    //public GameObject PlayerObj;
    private GameObject InputObj;
    private GameObject CalcResultObj;

    public int number
    {
        get
        {
            return _number;
        }
        set
        {
            _number = value;
        }
    }

    public void sendNumber()
    {
        _number = Convert.ToInt32(InputObj.GetComponent<InputField>().text);
        Debug.Log("Player's number = " + _number);
        this.CmdCalculate(_number);
    }

    [Command]
    void CmdCalculate(int nmb)
    {
        // This [Command] code is run on the server!
        Debug.Log("start calculating");

        int[] playerNumbers = new int[2];
        int sum;
        if (playerNumbers.Length == 0)
        {
            playerNumbers[0] = nmb;
        }
        else if (playerNumbers.Length == 1)
        {
            playerNumbers[1] = nmb;
        }

        if (playerNumbers.Length == 2)
        {
            sum = playerNumbers[0] + playerNumbers[1];

            //Result res = (Result)CalcResultObj.GetComponent("Result");
            //res._result = sum;
            //NetworkServer.Spawn(CalcResultObj);

            InpResult.text = sum.ToString();
        }
        else
        {
            return;
        }

        // spawn the bullet on the clients
        // NetworkServer.Spawn(bullet);

        // when the bullet is destroyed on the server it will automaticaly be destroyed on clients
        // Destroy(bullet, 2.0f);
    }

	// Use this for initialization
	void Start ()
    {
        InputObj = GameObject.Find("InpNumber");
        CalcResultObj = GameObject.Find("CalcResult");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
