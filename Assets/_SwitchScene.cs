using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public void _SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
