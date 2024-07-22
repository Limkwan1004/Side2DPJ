using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room : MonoBehaviour
{
    public int _Width;
    public int _Height;

    public string _RoomName;
    public string _RoomType;
    public string _RoomID;

    public Vector3Int _CenterPosition;
    public Vector3Int _ParentPosition;
    public Vector3Int _MergeCenterPosition;

    public int _Distance;

    public bool isUpdatedwalls = false;
    public bool isVisitedRoom = false;
    public GameObject _PrefabsDoor;
    public GameObject _PrefabsWall;

    public Room(int x,int y,int z)
    {
        _CenterPosition.x = x;
        _CenterPosition.y = y;
        _CenterPosition.z = z;
    }
    public SubRoom ChildRooms;

    public bool _UpdateRoomStatus = false;

    //Room을 생성 시 초기에 호출 시작
    public void SetupdateWalls(bool setup)
    {
        isUpdatedwalls = setup;
    }

    private void Start()
    {
        if (RoomController.Instance == null)
        {
            Debug.Log("You pressed play in the wrong scene!");
            return;
        }
        ChildRooms = GetComponent<SubRoom>();

        if (ChildRooms != null)
        {
            ChildRooms._CenterPosition      = _CenterPosition;
            ChildRooms._RoomType            = _RoomType;
            ChildRooms._Width               = _Width;
            ChildRooms._Height              = _Height;
            ChildRooms._RoomName            = _RoomName;
            ChildRooms._ParentPosition      = _ParentPosition;
            ChildRooms._MergeCenterPosition = _MergeCenterPosition;
        }
        isUpdatedwalls = false;
    }
    public void RemoveUnconnectedWalls()
    {
        if (ChildRooms != null)
        {
            ChildRooms.RemoveUnconnectedWalls();
        }
    }
    private void Update()
    {
        if (!isUpdatedwalls)
        {
            isUpdatedwalls = true;
        }
    }
    public Vector3 GetRoomCenter()
    {
        return new Vector3(_CenterPosition.x, 0, _CenterPosition.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RoomController.Instance.OnPlayerenterRoom(this);
        }
    }
}
