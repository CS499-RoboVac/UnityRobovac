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

    //Function to make a game object visible or invisible
    public void ToggleVisible(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
