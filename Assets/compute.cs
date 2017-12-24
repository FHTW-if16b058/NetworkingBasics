using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class compute : NetworkBehaviour
{

    private int[] _playerNumbers = new int[2];
    private static int _numberNumbers;
    public InputField input;
    //public InputField output;
    public GameObject ResultObject;

    // Use this for initialization
    void Start()
    {
        _numberNumbers = 0;
        //output.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void add()
    {
        int _number = Convert.ToInt32(input.text);
        Debug.Log("input = " + _number.ToString());

        if (_numberNumbers == 0)
        {
            _playerNumbers[0] = _number;
            _numberNumbers++;
        }
        else if (_numberNumbers == 1)
        {
            Debug.Log("nmb[0] = " + _playerNumbers[0].ToString());
            _playerNumbers[1] = _number;
            _numberNumbers++;
        }
        Debug.Log("have " + _numberNumbers + " numbers");

        if (_numberNumbers == 2)
        {
            _numberNumbers = 0;
            this.CmdCalculate();
        }
    }

    [Command]
    void CmdCalculate()
    {
        // This [Command] code is run on the server!
        Debug.Log("start calculating");

        int sum;
        
        if (isServer)
        {
            Debug.Log("nmb[0] = " + _playerNumbers[0].ToString());
            Debug.Log("nmb[1] = " + _playerNumbers[1].ToString());
            sum = _playerNumbers[0] + _playerNumbers[1];
            Debug.Log("sum = " + sum.ToString());
            //Result res = (Result)CalcResultObj.GetComponent("Result");
            //res._result = sum;
            //NetworkServer.Spawn(CalcResultObj);

            //output.text = sum.ToString();

            // in this case ResultObject needs to be instance
            //Result res = (Result)ResultObject.GetComponent("Result");
            //res._result = sum;
            //NetworkServer.Spawn(ResultObject);

            // in this case ResultObject needs to be prefab
            GameObject obj = (GameObject)Instantiate(ResultObject);
            Result res = (Result)obj.GetComponent("Result");
            res._result = sum;
            NetworkServer.Spawn(obj);
            
        }
        else
        {
            return;
        }
    }
}