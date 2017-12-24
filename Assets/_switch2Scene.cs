using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _switch2Scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void _SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
