using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class compute2 : NetworkBehaviour
{

    SyncListInt SyncListNmb = new SyncListInt();
    private static int _numberNumbers;
    public InputField input;
    //public InputField output;
    public GameObject ResultObject;
    public GameObject NumbersObject;

    // Use this for initialization
    void Start()
    {
        _numberNumbers = 0;
        //output.ActivateInputField();
        var obj = GameObject.Find("InpNumber");
        input = obj.GetComponent<InputField>();
        ResultObject = GameObject.Find("ResultObject");
        NumbersObject = GameObject.Find("NumbersObject");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendNumber()
    {
        if (!isClient) return;

        int _number = Convert.ToInt32(input.text);
        Debug.Log("input = " + _number.ToString());
        CmdAddNumber(_number);
    }

    [Command]
    void CmdAddNumber(int nmb)
    {
        if (!isServer) return;

        if (_numberNumbers < 2)
        {
            SyncListNmb.Add(nmb);
            _numberNumbers++;
        }

        Debug.Log("have " + _numberNumbers + " numbers");

        Numbers nmbrs = (Numbers)NumbersObject.GetComponent("Numbers");
        nmbrs._playerNumbers = SyncListNmb;
        NetworkServer.Spawn(NumbersObject);

        if (_numberNumbers == 2)
        {
            _numberNumbers = 0;
            this.CmdCalculate();
            SyncListNmb.Clear();
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
            //Numbers nmb = (Numbers)NumbersObject.GetComponent("Numbers");
            //SyncListInt _nmbSyncList = new SyncListInt();
            //_nmbSyncList = nmb._playerNumbers;

            Debug.Log("nmb[0] = " + SyncListNmb[0].ToString());
            Debug.Log("nmb[1] = " + SyncListNmb[1].ToString());
            sum = SyncListNmb[0] + SyncListNmb[1];
            Debug.Log("sum = " + sum.ToString());

            // in this case ResultObject needs to be instance
            Result res = (Result)ResultObject.GetComponent("Result");
            res._result = sum;
            NetworkServer.Spawn(ResultObject);

            // in this case ResultObject needs to be prefab
            //GameObject obj = (GameObject)Instantiate(ResultObject);
            //Result res = (Result)obj.GetComponent("Result");
            //res._result = sum;
            //NetworkServer.Spawn(obj);

        }
        else
        {
            return;
        }
    }
}
