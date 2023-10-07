using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RoomController : MonoBehaviour
{
    // Serializable Data struct for a Room
    [System.Serializable]
    public struct RoomData
    {
        public Vector2S Size;
        public Vector2S Position;
    }
    public RoomData roomData;

    // Wall Prefab
    public GameObject WallPrefab;

    public TextMeshProUGUI RoomSizeText;

    public Image RoomBackground;

    // Only used for previews
    public Color ValidColor;
    public Color InvalidColor;

    [HideInInspector]
    public bool Valid = true;

    private GameObject[] Walls;
    // Start is called before the first frame update


    void Start()
    {
        // Make sure there are 4 walls
        Walls = new GameObject[4];
        for(int i = 0; i < 4; i++)
        {
            Walls[i] = Instantiate(WallPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }

        // If the RoomData is null, set it from the Room's position
        if(roomData.Equals(null))
        {
            // Log that the RoomData was null
            Debug.Log("RoomData was null, setting from position");

            roomData.Position = new Vector2S(transform.position.x, transform.position.y);
        }
        
        RoomResize();
    }

    // Called when the Room is resized in the Level Editor
    public void RoomResize()
    {
        // Set the room's position
        transform.position = new Vector3(roomData.Position.x, roomData.Position.y, 0);

        // Calculate the room's size for the SizeText
        float roomSize = roomData.Size.x * roomData.Size.y;

        // Set the RoomSizeText to the room's size
        RoomSizeText.text = roomSize.ToString() + " sq. ft.";

        // Move the RoomSizeText to the center of the Room
        RoomSizeText.transform.position = new Vector3(roomData.Position.x, roomData.Position.y, 0);

        // Scale the RoomBackground to the room's size
        RoomBackground.rectTransform.localScale = new Vector2(roomData.Size.x, roomData.Size.y);

        // Based on the RoomData, set the Room's size and position
        // Set the Room's walls based on the RoomData
        // Top Wall
        Walls[0].transform.localScale = new Vector3(roomData.Size.x, 0.1f, 1);
        Walls[0].transform.position = new Vector3(roomData.Position.x, roomData.Position.y + roomData.Size.y / 2, 0);
        // Left Wall
        Walls[1].transform.localScale = new Vector3(0.1f, roomData.Size.y, 1);
        Walls[1].transform.position = new Vector3(roomData.Position.x - roomData.Size.x / 2, roomData.Position.y, 0);
        // Right Wall
        Walls[2].transform.localScale = new Vector3(0.1f, roomData.Size.y, 1);
        Walls[2].transform.position = new Vector3(roomData.Position.x + roomData.Size.x / 2, roomData.Position.y, 0);
        // Bottom Wall
        Walls[3].transform.localScale = new Vector3(roomData.Size.x, 0.1f, 1);
        Walls[3].transform.position = new Vector3(roomData.Position.x, roomData.Position.y - roomData.Size.y / 2, 0);

        // If the room is valid, set the wall colors to the valid color, otherwise set them to the invalid color
        if(Valid)
        {
            for(int i = 0; i < 4; i++)
            {
                Walls[i].GetComponent<SpriteRenderer>().color = ValidColor;
            }
        }
        else
        {
            for(int i = 0; i < 4; i++)
            {
                Walls[i].GetComponent<SpriteRenderer>().color = InvalidColor;
            }
        }
    }

    void OnDestroy()
    {
        // Destroy the walls
        for(int i = 0; i < 4; i++)
        {
            Destroy(Walls[i]);
        }
    }

}
