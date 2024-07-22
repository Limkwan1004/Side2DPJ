using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMiniMap : MonoBehaviour
{
    public GameObject _FloorMap;
    public bool _VisitedRoom = false;

    public List<Wall> _Walls;
    public Wall LeftWall;
    public Wall RightWall;
    public Wall TopWall;
    public Wall BottomWall;

    public GameObject _CurrRoom;
    public bool _Visited = false;

    private void Start()
    {
        transform.gameObject.SetActive(false);
        _FloorMap.GetComponentInChildren<MeshRenderer>().material = RoomController.Instance._DefaultBackground;

        Wall[] ws = GetComponentsInChildren<Wall>();

        foreach (Wall w in ws)
        {
            _Walls.Add(w);

            switch (w._WallType)
            {
                case WallType.left:
                    LeftWall = w;
                    break;
                case WallType.right:
                    RightWall = w;
                    break;
                case WallType.top:
                    TopWall = w;
                    break;
                case WallType.bottom:
                    BottomWall = w;
                    break;
                default:
                    break;
            }
        }
        MiniMapWallSet(true);
    }
    public void VisitiedRoom(bool boolean,bool currentBool)
    {
        transform.gameObject.SetActive(boolean);
        if (currentBool)
        {
            _Visited = true;
        }
        MiniMapWallSet(true);
    }
    public void VisitiedCurrentRoom(bool boolean)
    {
        //4. 현재 위치 밝게 처리
        if (boolean)
        {
            _FloorMap.GetComponentInChildren<MeshRenderer>().material = RoomController.Instance._CurrentMaterial;
        }
        else
        {
            if (_Visited)
            {
                _FloorMap.GetComponentInChildren<MeshRenderer>().material = RoomController.Instance._VisitedBack;
            }
            else
            {
                _FloorMap.GetComponentInChildren<MeshRenderer>().material = RoomController.Instance._DefaultBackground;
            }
        }
    }
    public void MiniMapWallSet(bool boolean)
    {
        if (_Visited || boolean)
        {
            for (int i = 0; i < _Walls.Count; i++)
            {
                if (_Walls[i].isSetUp)
                {
                    _Walls[i].transform.gameObject.SetActive(boolean);
                }
                
            }
        }
        else
        {
            for (int i = 0; i < _Walls.Count; i++)
            {
                if (_Walls[i].isSetUp)
                {
                    _Walls[i].transform.gameObject.SetActive(boolean);
                }
            }
        }
    }

}
