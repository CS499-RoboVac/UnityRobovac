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
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        
        float size = 0f;

        try
        {
            size = Convert.ToSingle(SizeText.GetComponent<TMP_InputField>().text);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        
        if(size < 2)
        {
            size = 2;
        }
        editor.PassedSize = size;
        editor.CurrentButtonPressed = ID;
        Clicked = true;

        var ItemPreview = Instantiate(editor.ItemPreview[ID], new Vector3(worldPosition.x, worldPosition.y, 0), Quaternion.identity);
        if(ItemPreview.GetComponent<RoomController>() != null)
        {
            ItemPreview.GetComponent<RoomController>().roomData.Position = new Vector2S(worldPosition.x, worldPosition.y);
            ItemPreview.GetComponent<RoomController>().roomData.Size = new Vector2S(editor.getPassedSize(), editor.getPassedSize());
        }
    }
}


