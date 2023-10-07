using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorManager : MonoBehaviour
{
    public ItemController[] ItemButtons;
    public GameObject[] ItemPrefabs;
    public GameObject[] ItemPreview;
    // The scale of one foot into unity units
    public float scale = 1.0f;

    [HideInInspector]
    public int CurrentButtonPressed;
    [HideInInspector]
    public float PassedSize;
    [HideInInspector]
    public bool canPlace = false;

    // Gets the scaled value of the passed size
    public float getPassedSize()
    {
        return PassedSize*scale;
    }
    
    private void Update()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if(Input.GetMouseButtonDown(0) && ItemButtons[CurrentButtonPressed].Clicked)
        {
            ItemButtons[CurrentButtonPressed].Clicked = false;
            GameObject createdObject = Instantiate(ItemPrefabs[CurrentButtonPressed], new Vector3(worldPosition.x, worldPosition.y, 0), Quaternion.identity);
            // Destroy the preview object
            Destroy(GameObject.FindGameObjectWithTag("ItemPreview"));
            if(createdObject.GetComponent<RoomController>() != null)
            {
                createdObject.GetComponent<RoomController>().roomData.Position = new Vector2S(worldPosition.x, worldPosition.y);
                createdObject.GetComponent<RoomController>().roomData.Size = new Vector2S(getPassedSize(), getPassedSize());
            }
        }
    }
}
