using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public LevelEditorManager editor;

    private RoomController roomController;
    private bool canPlace = true;
    void Start()
    {
        editor = GameObject.Find("LevelEditorManager").GetComponent<LevelEditorManager>();
        roomController = GetComponent<RoomController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = worldPosition;
        
        // If the object has a room controller, set the position in the room data
        if(roomController != null)
        {
            roomController.roomData.Position = new Vector2S(worldPosition.x, worldPosition.y);
            roomController.RoomResize();

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Room")
        {
            editor.canPlace = false;
            canPlace = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Room")
        {
            editor.canPlace = true;
            canPlace = true;
        }
    }
}
