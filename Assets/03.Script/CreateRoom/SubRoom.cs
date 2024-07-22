using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubRoom : MonoBehaviour
{
    public int _Width;
    public int _Height;

    public string _RoomName;
    public string _RoomType;

    //각 방의 문을 세팅
    public List<Door> _Doors;
    public Door _LeftDoor;
    public Door _RightDoor;
    public Door _TopDoor;
    public Door _BottomDoor;

    public List<Wall> _Walls;
    public Wall _LeftWall;
    public Wall _RightWall;
    public Wall _TopWall;
    public Wall _BottomWall;

    //현재 방 위치
    public Vector3Int _CenterPosition;
    public Vector3Int _ParentPosition;
    public Vector3Int _MergeCenterPosition;
    public string _WallType;

    public Room _ParentRoom;
    public bool isUpdatedRooms = false;
    public bool isRoomparhBool = false;
    public RoomMiniMap _MinimapRoom;

    private void Start()
    {
        Door[] ds = GetComponentsInChildren<Door>();

        foreach (Door d in ds)
        {
            _Doors.Add(d);

            switch (d._DoorType)
            {
                case DoorType.left:
                    _LeftDoor = d;
                    break;
                case DoorType.right:
                    _RightDoor = d;
                    break;
                case DoorType.top:
                    _TopDoor = d;
                    break;
                case DoorType.bottom:
                    _BottomDoor = d;
                    break;
            }
        }
        Wall[] ws = GetComponentsInChildren<Wall>();

        foreach (Wall w in ws)
        {
            //Door 리스트에 Door를 삽입
            _Walls.Add(w);

            switch (w._WallType)
            {
                case WallType.left:
                    _LeftWall = w;
                    break;
                case WallType.right:
                    _RightWall = w;
                    break;
                case WallType.top:
                    _TopWall = w;
                    break;
                case WallType.bottom:
                    _BottomWall = w;
                    break;                
            }
        }
        
    }

    private void Update()
    {
        RoomUpdate();
    }

    private void RoomUpdate()
    {
        if (!isUpdatedRooms)
        {
            //

            isUpdatedRooms = true;
        }
    }

    public void UpdateRoomSetUp()
    {
        if (!_RoomType.Equals("Single"))
        {
            _ParentRoom = RoomController.Instance.FindRoom(_ParentPosition.x, _ParentPosition.y, _ParentPosition.z);

            GameObject tmpChildRoom = gameObject;

            tmpChildRoom.transform.SetParent(_ParentRoom.transform);
            tmpChildRoom.transform.parent.GetComponent<Room>().SetupdateWalls(false);

            GameObject miniRoom = _MinimapRoom.gameObject;
            _MinimapRoom.transform.SetParent(_ParentRoom.transform);
        }
    }

    public void MinimapUpdate()
    {
        for (int i = 0; i < RoomController.Instance._LoadedRooms.Count; i++)
        {
            if (_ParentPosition == RoomController.Instance._LoadedRooms[i]._ParentPosition)
            {
                RoomController.Instance._LoadedRooms[i].isVisitedRoom = true;
                RoomController.Instance._LoadedRooms[i].ChildRooms._MinimapRoom.VisitiedRoom(true,true);
                RoomController.Instance._LoadedRooms[i].ChildRooms._MinimapRoom.VisitiedCurrentRoom(true);
                
            }
            else
            {
                RoomController.Instance._LoadedRooms[i].ChildRooms._MinimapRoom.VisitiedCurrentRoom(false);
            }
        }

        //2. 인접한 Room에 대해서 visible
        if (GetRight()!= null)
        {
            MiniMapUpdateSide(GetRight());
        }
        if (GetLeft() != null)
        {
            MiniMapUpdateSide(GetLeft());
        }
        if (GetTop() != null)
        {
            MiniMapUpdateSide(GetTop());
        }
        if (GetBottom() != null)
        {
            MiniMapUpdateSide(GetBottom());
        }
    }
    public void MiniMapUpdateSide(Room room)
    {
        for (int i = 0; i < RoomController.Instance._LoadedRooms.Count; i++)
        {
            if (room._ParentPosition == RoomController.Instance._LoadedRooms[i]._ParentPosition)
            {
                RoomController.Instance._LoadedRooms[i].ChildRooms._MinimapRoom.VisitiedRoom(true,false);
            }
        }
    }
    public Room GetRight()
    {
        if (RoomController.Instance.DoesRoomExist(_CenterPosition.x + 1, _CenterPosition.y, _CenterPosition.z))
        {
            return RoomController.Instance.FindRoom(_CenterPosition.x + 1, _CenterPosition.y, _CenterPosition.z);
        }
        return null;
    }
    public void RemoveUnconnectedWalls()
    {
        Vector3 tmpCenterPos = transform.parent.gameObject.GetComponent<Room>()._ParentPosition;
        string wallStr = string.Empty;

        foreach (Wall wall in _Walls)
        {
            switch (wall._WallType)
            {
                case WallType.left:
                    if (GetLeft()!= null)
                    {
                        Room leftRoom = GetLeft();

                        if (leftRoom._ParentPosition == tmpCenterPos)
                        {
                            _LeftDoor.gameObject.SetActive(false);
                            _LeftWall.gameObject.SetActive(false);

                            _MinimapRoom.LeftWall.gameObject.SetActive(false);
                            _MinimapRoom.LeftWall.isSetUp = false;
                        }
                        else
                        {
                            wallStr += "Left";
                            if (!_LeftDoor.isUpdate)
                            {
                                GameObject roomDoor = Instantiate(leftRoom._PrefabsDoor, _LeftDoor.transform);
                                roomDoor.gameObject.transform.SetParent(leftRoom.gameObject.transform);
                                _LeftDoor.SetNextRoom(leftRoom.gameObject);
                                _LeftDoor._SideDoor = leftRoom.ChildRooms._RightDoor;

                                _LeftDoor.isUpdate = true;
                            }
                        }
                    }
                    else
                    {
                        if (!_LeftWall.isUpdate)
                        {
                            GameObject newWall = transform.parent.GetComponent<Room>()._PrefabsWall.gameObject;
                            GameObject roomWall = Instantiate(newWall, _LeftWall.transform);
                        }

                        _LeftDoor.gameObject.SetActive(false);
                    }                    
                    break;

                case WallType.right:
                    if (GetRight() != null)
                    {
                        Room rightRoom = GetRight();
                        if (rightRoom._ParentPosition == tmpCenterPos)
                        {
                            _RightDoor.gameObject.SetActive(false);
                            _RightWall.gameObject.SetActive(false);

                            _MinimapRoom.RightWall.gameObject.SetActive(false);
                            _MinimapRoom.RightWall.isSetUp = false;

                        }
                        else
                        {
                            wallStr += "Rright";
                            if (!_RightDoor.isUpdate)
                            {
                                GameObject roomDoor = Instantiate(rightRoom._PrefabsDoor, _RightDoor.transform);
                                roomDoor.gameObject.transform.SetParent(_RightDoor.gameObject.transform);

                                _RightDoor.SetNextRoom(rightRoom.gameObject);
                                _RightDoor._SideDoor= rightRoom.ChildRooms._LeftDoor;

                                _RightDoor.isUpdate = true;
                            }
                        }
                    }
                    else
                    {
                        if (!_RightWall.isUpdate)
                        {
                            GameObject newWall = transform.parent.GetComponent<Room>()._PrefabsWall.gameObject;
                            GameObject roomWall = Instantiate(newWall, _RightWall.transform);
                            _RightWall.isUpdate = true;
                        }

                        _RightDoor.gameObject.SetActive(false);
                    }
                    break;
                case WallType.top:
                    if (GetTop() != null)
                    {
                        Room topRoom = GetTop();

                        if (topRoom._ParentPosition == tmpCenterPos)
                        {
                            _TopDoor.gameObject.SetActive(false);
                            _TopWall.gameObject.SetActive(false);
                            _MinimapRoom.TopWall.gameObject.SetActive(false);
                            _MinimapRoom.TopWall.isSetUp = false;

                        }
                        else
                        {
                            wallStr += "Top";
                            if (!_TopDoor.isUpdate)
                            {
                                GameObject roomDoor = Instantiate(topRoom._PrefabsDoor, _TopDoor.transform);
                                roomDoor.gameObject.transform.SetParent(_TopDoor.gameObject.transform);
                                _TopDoor.SetNextRoom(topRoom.gameObject);
                                _TopDoor._SideDoor = topRoom.ChildRooms._BottomDoor;

                                _TopDoor.isUpdate = true;
                            }
                        }
                    }
                    else
                    {
                        if (!_TopWall.isUpdate)
                        {
                            GameObject newWall = transform.parent.GetComponent<Room>()._PrefabsWall.gameObject;
                            GameObject roomWall = Instantiate(newWall, _TopWall.transform);
                            _TopWall.isUpdate = true;
                        }

                        _TopDoor.gameObject.SetActive(false);
                    }
                    break;
                    
                case WallType.bottom:
                    if (GetBottom() != null)
                    {
                        Room bottomRoom = GetBottom();

                        if (bottomRoom._ParentPosition == tmpCenterPos)
                        {
                            // 방이 뚫려 있다.
                            _BottomDoor.gameObject.SetActive(false);
                            _BottomWall.gameObject.SetActive(false);

                            _MinimapRoom.BottomWall.gameObject.SetActive(false);
                            _MinimapRoom.BottomWall.isSetUp = false;

                        }
                        else
                        {
                            wallStr += "Bottom";
                            if (!_BottomDoor.isUpdate)
                            {
                                GameObject roomDoor = Instantiate(bottomRoom._PrefabsDoor, _BottomDoor.transform);
                                roomDoor.gameObject.transform.SetParent(_BottomDoor.gameObject.transform);

                                _BottomDoor.SetNextRoom(bottomRoom.gameObject);
                                _BottomDoor._SideDoor = bottomRoom.ChildRooms._TopDoor;

                                _BottomDoor.isUpdate = true;
                            }
                        }
                    }
                    else
                    {

                        if (!_BottomDoor.isUpdate)
                        {
                            GameObject newWall = transform.parent.GetComponent<Room>()._PrefabsWall.gameObject;
                            GameObject roomWall = Instantiate(newWall, _BottomWall.transform);
                            _BottomWall.isUpdate = true;
                        }
                        _BottomDoor.gameObject.SetActive(false);
                    }
                    break;              
            }
        }
        if (wallStr != "")
        {
            _WallType = wallStr;
        }
        else
        {
            _WallType = "None";
        }
    }
    public Room GetLeft()
    {
        if (RoomController.Instance.DoesRoomExist(_CenterPosition.x - 1, _CenterPosition.y, _CenterPosition.z))
        {
            return RoomController.Instance.FindRoom(_CenterPosition.x - 1, _CenterPosition.y, _CenterPosition.z);
        }
        return null;
    }

    public Room GetTop()
    {
        if (RoomController.Instance.DoesRoomExist(_CenterPosition.x, _CenterPosition.y, _CenterPosition.z + 1))
        {
            return RoomController.Instance.FindRoom(_CenterPosition.x, _CenterPosition.y, _CenterPosition.z + 1);
        }
        return null;
    }

    public Room GetBottom()
    {
        if (RoomController.Instance.DoesRoomExist(_CenterPosition.x,_CenterPosition.y,_CenterPosition.z - 1))
        {
            return RoomController.Instance.FindRoom(_CenterPosition.x, _CenterPosition.y, _CenterPosition.z - 1);
        }
        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            RoomController.Instance.OnPlayerenterRoom(transform.parent.GetComponent<Room>());
        }
    }
}
