using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCrawlerController : MonoBehaviour
{

    #region//4방향
    public List<Vector3Int> _Direction4 = new List<Vector3Int>
    {
        new Vector3Int( 1, 0, 0),      //Right
        new Vector3Int(-1, 0, 0),      //Left
        new Vector3Int( 0, 0, 1),      //Top
        new Vector3Int( 0, 0,-1),      //Bottom

    };
    #endregion

    #region//8방향
    public List<Vector3Int> _Direction8 = new List<Vector3Int>
    {
        //Right                         //Left
        new Vector3Int( 1, 0, 0),       new Vector3Int(-1, 0, 0),
        //Top                           //Bottom
        new Vector3Int( 0, 0, 1),       new Vector3Int( 0, 0,-1),
        //TopRight                      //BottomLeft
        new Vector3Int( 1, 0, 1),       new Vector3Int(-1, 0,-1),
        //DownRight                     //TopLeft
        new Vector3Int( 1, 0,-1),       new Vector3Int(-1, 0,-1),
    };
    #endregion

    #region 4방향 기준 Pattern
    public Dictionary<int, List<Vector3Int>> _RightPattern = new Dictionary<int, List<Vector3Int>>
    {
        { 0, new List<Vector3Int> { new Vector3Int( 1, 0, 0), new Vector3Int( 2, 0, 0), new Vector3Int( 1, 0,-1), new Vector3Int(2, 0, 1) } },
        { 1, new List<Vector3Int> { new Vector3Int( 1, 0, 0), new Vector3Int( 2, 0, 0), new Vector3Int( 2, 0,-1) } }, // ┓
        { 2, new List<Vector3Int> { new Vector3Int( 1, 0, 0), new Vector3Int( 2, 0, 0), new Vector3Int( 2, 0, 1) } }, // ┛
        { 3, new List<Vector3Int> { new Vector3Int( 1, 0, 0), new Vector3Int( 2, 0, 0)                          } }, // 오른쪽 --
        { 4, new List<Vector3Int> { new Vector3Int( 1, 0, 0), new Vector3Int( 1, 0, 1)                          } }, // 오른쪽 --
        { 5, new List<Vector3Int> { new Vector3Int( 1, 0, 0), new Vector3Int( 1, 0,-1)                          } }, // 오른쪽 --
        { 6, new List<Vector3Int> { new Vector3Int( 1, 0, 0)                                                    } }, // 오른쪽 --
    };
    public Dictionary<int, List<Vector3Int>> _LeftPattern = new Dictionary<int, List<Vector3Int>>
    {
        { 0, new List<Vector3Int> { new Vector3Int(-1, 0, 0), new Vector3Int(-2, 0, 0), new Vector3Int(-1, 0,-1), new Vector3Int(-2, 0,-1) } },
        { 1, new List<Vector3Int> { new Vector3Int(-1, 0, 0), new Vector3Int(-2, 0, 0), new Vector3Int(-2, 0,-1) } }, // └
        { 2, new List<Vector3Int> { new Vector3Int(-1, 0, 0), new Vector3Int(-2, 0, 0), new Vector3Int(-2, 0, 1) } }, // ┏
        { 3, new List<Vector3Int> { new Vector3Int(-1, 0, 0), new Vector3Int(-2, 0, 0)                          } }, // 왼쪽 --
        { 4, new List<Vector3Int> { new Vector3Int(-1, 0, 0), new Vector3Int(-1, 0,-1)                          } }, // 왼쪽 --
        { 5, new List<Vector3Int> { new Vector3Int(-1, 0, 0), new Vector3Int(-1, 0, 1)                          } }, // 왼쪽 --
        { 6, new List<Vector3Int> { new Vector3Int(-1, 0, 0)                                                    } }, // 왼쪽 --
    };
    public Dictionary<int, List<Vector3Int>> _TopPattern = new Dictionary<int, List<Vector3Int>>
    {
        { 0, new List<Vector3Int> { new Vector3Int( 0, 0,-1), new Vector3Int( 0, 0,-2), new Vector3Int(-1, 0,-1), new Vector3Int(-1, 0,-2) } },
        { 1, new List<Vector3Int> { new Vector3Int( 0, 0,-1), new Vector3Int( 0, 0,-2), new Vector3Int( 1, 0,-2) } }, // ┏
        { 2, new List<Vector3Int> { new Vector3Int( 0, 0,-1), new Vector3Int( 0, 0,-2), new Vector3Int(-1, 0,-2) } }, // ┓
        { 3, new List<Vector3Int> { new Vector3Int( 0, 0,-1), new Vector3Int( 0, 0,-2)                          } }, // 위 |
        { 4, new List<Vector3Int> { new Vector3Int( 0, 0,-1), new Vector3Int( 1, 0,-1)                          } }, // 위 |
        { 5, new List<Vector3Int> { new Vector3Int( 0, 0,-1), new Vector3Int(-1, 0,-1)                          } }, // 위 |
        { 6, new List<Vector3Int> { new Vector3Int( 0, 0,-1)                                                    } }, // 위 |
    };
    public Dictionary<int, List<Vector3Int>> _BottomPattern = new Dictionary<int, List<Vector3Int>>
    {
        { 0, new List<Vector3Int> { new Vector3Int( 0, 0, 1), new Vector3Int(-1, 0, 1), new Vector3Int( 0, 0, 2), new Vector3Int(-1, 0, 2) } },
        { 1, new List<Vector3Int> { new Vector3Int( 0, 0, 1), new Vector3Int( 0, 0, 2), new Vector3Int(-1, 0, 2) } }, // ┓
        { 2, new List<Vector3Int> { new Vector3Int( 0, 0, 1), new Vector3Int( 0, 0, 2), new Vector3Int( 1, 0, 2) } }, // ┏
        { 3, new List<Vector3Int> { new Vector3Int( 0, 0, 1), new Vector3Int( 0, 0, 2)                          } }, // 아래 |
        { 4, new List<Vector3Int> { new Vector3Int( 0, 0, 1), new Vector3Int(-1, 0, 1)                          } }, // 아래 |
        { 5, new List<Vector3Int> { new Vector3Int( 0, 0, 1), new Vector3Int( 1, 0, 1)                          } }, // 아래 |
        { 6, new List<Vector3Int> { new Vector3Int( 0, 0, 1)                                                    } }, // 아래 |
    };

    #endregion

    //유효한 방을 담을 리스트
    public List<RoomInfo> _ValidRoomList = new List<RoomInfo>();

    public int _MinRoomCount = 15;          //최소 방 갯수
    public int _MaxRoomCount = 20;          //최대 방 갯수
    public int _CurrentRoomCount = 0;       //현재 방 갯수
    public int _MaxDistance = 5;            //최대 거리 제한

    public int _ValidRoomCount = 0;         //유효한 방 갯수

    public Vector3Int _StartRoomPosition;   //시작 위치
    public Vector3Int _BossRoomPosition;    //보스방 위치

    public RoomInfo[,] _PossArr = new RoomInfo[10, 10]; //방 좌표에 대한 2차원

    public void CreatedRoom()
    {
        _PossArr = (RoomInfo[,])ResizeArray(_PossArr, new int[] { (_MaxDistance * 2), (_MaxDistance * 2) });

    }


    //방의 갯수가 최소, 최대 크기에 적합한지 체크
    private static Array ResizeArray(Array arr, int[] newSize)
    {
        if (newSize.Length!= arr.Rank)
        {
            return null;
        }

        var temp = Array.CreateInstance(arr.GetType().GetElementType(), newSize);
        int length = arr.Length <= temp.Length ? arr.Length : temp.Length;
        return temp;
    }
}
