using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public RoomContent[] Rooms;
    private int currentRoomNumber;

    private SceneTransition sceneTransition;
    public string SceneToLoad;

    public BasePlayer Player;
    private CharacterController charController;

    private void Awake()
    {
        charController = Player.GetComponent<CharacterController>();
        sceneTransition = GetComponent<SceneTransition>();
        foreach (var room in Rooms)
        {
            room.Teleport.PlayerInPortal += OnPlayerInPortal;
        }
        currentRoomNumber = 0;
        LoadRoom(currentRoomNumber);
    }

    private void OnPlayerInPortal()
    {
        currentRoomNumber++;
        LoadRoom(currentRoomNumber);
    }

    private void LoadRoom(int roomNumber)
    {
        if (roomNumber >= Rooms.Length)
        {
            sceneTransition.OnSceneEnter(SceneToLoad);
            return;
        }

        for (int i = 0; i < Rooms.Length; i++)
        {
            Rooms[i].gameObject.SetActive(i == roomNumber);

            charController.enabled = false;
            Player.transform.position = Rooms[currentRoomNumber].PlayerSpawn.position;
            Player.transform.rotation = Quaternion.identity;
            charController.enabled = true;
        }
    }
}
