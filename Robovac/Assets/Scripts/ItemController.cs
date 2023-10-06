using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemController: MonoBehaviour
{
    public int ID;
    public GameObject SizeText;
    private LevelEditorManager editor;

    [HideInInspector]
    public bool Clicked = false;

    void Start()
    {
        editor = GameObject.Find("LevelEditorManager").GetComponent<LevelEditorManager>();
    }
    public void ButtonPressed()
    {
        
        float size = Convert.ToSingle(SizeText.GetComponent<TMP_InputField>().text);
        if(size < 2)
        {
            size = 2;
        }
        editor.PassedSize = size;
        editor.CurrentButtonPressed = ID;
        Clicked = true;
    }
}


