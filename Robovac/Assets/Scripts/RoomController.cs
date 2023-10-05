using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when the Room is resized in the Level Editor
    public void RoomResize()
    {
        // Set the room's position
        transform.position = new Vector3(roomData.Position.x, roomData.Position.y, 0);

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
    }
}
