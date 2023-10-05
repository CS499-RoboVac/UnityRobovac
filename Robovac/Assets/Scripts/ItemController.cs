using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController: MonoBehaviour
{
    public int ID;
    private LevelEditorManager editor;

    [HideInInspector]
    public bool Clicked = false;

    void Start()
    {
        editor = GameObject.Find("LevelEditorManager").GetComponent<LevelEditorManager>();
    }
    public void ButtonPressed()
    {
        editor.CurrentButtonPressed = ID;
        Clicked = true;
    }
}


