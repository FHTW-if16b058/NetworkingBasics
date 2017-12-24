using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class compute : NetworkBehaviour
{
    SyncListInt SyncListNmb = new SyncListInt();        // 'array' für ints
    private static int _numberNumbers;                  // Anzahl der Elemente in der Liste
    public InputField input;                            // Eingabefeld
    public GameObject NumbersObject;                    // Objekt für die eingegebenen Zahlen; wird benötigt, damit man das 'array' spawnen kann
    public GameObject ResultObject;                     // Objekt für das Ergebnis; wird benötigt, damit man das Ergebnis spawnen kann


    // Use this for initialization
    void Start()                                        // Objekte initialisieren
    {
        _numberNumbers = 0;
        var obj = GameObject.Find("InpNumber");
        input = obj.GetComponent<InputField>();
        ResultObject = GameObject.Find("ResultObject");
        NumbersObject = GameObject.Find("NumbersObject");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void add()
    {
        int _number = Convert.ToInt32(input.text);
        Debug.Log("input = " + _number.ToString());        

        if (_numberNumbers < 2)                         // Zahl hinzufügen
        {
            SyncListNmb.Add(_number);
            _numberNumbers++;
        }

        Debug.Log("have " + _numberNumbers + " numbers");

        if (isServer)
        {
            Numbers nmb = (Numbers)NumbersObject.GetComponent("Numbers");   // NumbersObject spawnen
            nmb._playerNumbers = SyncListNmb;
            NetworkServer.Spawn(NumbersObject);
        }

        if (_numberNumbers == 2)                                            // wenn 2 Zahlen vorhanden sind, wird das Ergebnis berechnet und das 'array' zurückgesetzt
        {
            _numberNumbers = 0;
            this.CmdCalculate();
            SyncListNmb.Clear();
        }
    }

    [Command]
    public void CmdCalculate()
    {
        // This [Command] code is run on the server!
        Debug.Log("start calculating");

        int sum;

        if (isServer)
        {
            //Numbers nmb = (Numbers)NumbersObject.GetComponent("Numbers");
            //SyncListInt _nmbSyncList = new SyncListInt();
            //_nmbSyncList = nmb._playerNumbers;

            Debug.Log("nmb[0] = " + SyncListNmb[0].ToString());             // Zahlen aus dem 'array' holen und addieren  
            Debug.Log("nmb[1] = " + SyncListNmb[1].ToString());
            sum = SyncListNmb[0] + SyncListNmb[1];
            Debug.Log("sum = " + sum.ToString());

            // in this case ResultObject needs to be instance
            Result res = (Result)ResultObject.GetComponent("Result");       // Ergebnis spawnen
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