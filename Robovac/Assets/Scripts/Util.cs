using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
   //Function to load scene by name
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    //Function to print message to console
    public void PrintMessage(string message)
    {
        Debug.Log(message);
    }
}
