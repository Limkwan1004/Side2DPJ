using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public static RoomController Instance = null;

    public string _GlobalRoomTitle = "Basement";

    public RoomInfo currentLoadRoomData;
    public Room _CurrentRoom;

    public List<Room> _LoadedRooms = new List<Room>();

    public Material _DefaultBackground;
    public Material _VisitedBack;
    public Material _CurrentMaterial;

    public bool isLoadingRoom = false;
        

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CreatedRoom()
    {
        isLoadingRoom = false;

        for (int i = 0;  i< transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        _LoadedRooms.Clear();

        //Player.Instance.Transform.position = new Vector3(0,0.5f,0);

        DungeonCrawlerController.Instance.CreatedRoom();
               

    }
    private void SetRoomPath()
    {
        if (isLoadingRoom)
        {
            return;
        }

        if (_LoadedRooms.Count>0)
        {
            foreach (Room room in _LoadedRooms)
            {
                room.RemoveUnconnectedWalls();
            }
            isLoadingRoom = true;
        }
    }

    public void LoadRoom(RoomInfo settingRoom)
    {
        if (DoesRoomExist(settingRoom._CenterPosition.x, settingRoom._CenterPosition.y, settingRoom._CenterPosition.z))
        {
            return;
        }

        string roomPreName = settingRoom._RoomName;

        GameObject room = Instantiate(RoomPrefabsSet.Instance._RoomPrefabs[roomPreName]);

        room.transform.position = new Vector3(
                    (settingRoom._CenterPosition.x * room.transform.GetComponent<Room>()._Width),
                    settingRoom._CenterPosition.y,
                    settingRoom._CenterPosition.z * room.transform.GetComponent<Room>()._Height);

        room.transform.localScale = new Vector3(
            (room.transform.GetComponent<Room>()._Width / 10), 1, (room.transform.GetComponent<Room>()._Height / 10));

        room.transform.GetComponent<Room>()._CenterPosition = settingRoom._CenterPosition;
        room.name = _GlobalRoomTitle + "-" + settingRoom._RoomName + " " + settingRoom._CenterPosition.x + ", " + settingRoom._CenterPosition.z;

        room.transform.GetComponent<Room>()._RoomName = settingRoom._RoomName;
        room.transform.GetComponent<Room>()._RoomType = settingRoom._RoomType;
        room.transform.GetComponent<Room>()._RoomID = settingRoom._RoomID;
        room.transform.GetComponent<Room>()._ParentPosition = settingRoom._ParentPosition;
        room.transform.GetComponent<Room>()._MergeCenterPosition = settingRoom._MergeCenterPosition;
        room.transform.GetComponent<Room>()._Distance= settingRoom._Distance;

        room.transform.parent = transform;

        _LoadedRooms.Add(room.GetComponent<Room>());

    }
    
    public bool DoesRoomExist(int x, int y, int z)
    {
        //빈 데이터 혹은 삭제된 방이 있을 경우를 위한 에외 처리
        return _LoadedRooms.Find(item => item._CenterPosition.x == x && item._CenterPosition.y == y && item._CenterPosition.z == z) != null;
    }
    public Room FindRoom(int x, int y, int z)
    {
        //List.Find : item 변수 조건에 맞는 Room을 찾아 반환
        return _LoadedRooms.Find(item => item._CenterPosition.x == x && item._CenterPosition.y == y && item._CenterPosition.z == z);
    }
    public void OnPlayerenterRoom(Room room)
    {
        
    }
}
