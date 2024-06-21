using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DungeonCrawlerController : MonoBehaviour
{
    public static DungeonCrawlerController Instance = null;

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

    public RoomInfo[,] _PosArr = new RoomInfo[10, 10]; //방 좌표에 대한 2차원

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
            return;
        }
    }


    public void CreatedRoom()
    {

        //배열 ReSize
        _PosArr = (RoomInfo[,])ResizeArray(_PosArr, new int[] { (_MaxDistance * 2), (_MaxDistance * 2) });

        int x = UnityEngine.Random.Range(0, _MaxDistance) + (_MaxDistance);     //최대 크기 X 좌표
        int z = UnityEngine.Random.Range(0, _MaxDistance) + (_MaxDistance);     //최대 크기 Y 좌표

        _StartRoomPosition = new Vector3Int(x, 0, z);                           //시작 좌표

        //_PossArr[_StartRoomPosition.z,_StartRoomPosition.x] =
        _PosArr[_StartRoomPosition.z, _StartRoomPosition.x]._Distance = 0;
        _CurrentRoomCount++;
    }
    
    public RoomInfo AddSingleRoom(RoomInfo room, Vector3Int pos, string name)
    {   //방의 정보 입력
        RoomInfo single = room;
        single._RoomID = name+ "(" + pos.x + ", " + pos.y + ", " + pos.z + ")";
        single._RoomName = name;
        single._CenterPosition = pos;
        single._ParentPosition = pos;
        single._RoomType = "Single";
        single._isValidRoom = true;
        return single;
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

    public void SortRoomList(List<RoomInfo> root)
    {
        //각 방의 크기를 비교하여 값 반환
        root.Sort(delegate (RoomInfo A, RoomInfo B)
        {
            if (A._Distance > B._Distance)
            {
                return 1;
            }
            else if (A._Distance < B._Distance)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        });
    }
    public bool PossibleArr(Vector3Int pos)
    {
        if ((0<= (pos).x&&(pos).x<(_MaxDistance*2))&&
            (0 <= (pos).z && (pos).z < (_MaxDistance * 2)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddBossRoom()
    {
        SortRoomList(_ValidRoomList);

        bool selectBossRoomStatus = false;

        for (int index = _ValidRoomList.Count; 0 < index; index++)
        {
            if (!selectBossRoomStatus)
            {
                int setListCnt = index;
                Vector3Int pos = _ValidRoomList[setListCnt]._CenterPosition;

                for (int i = 0; i < 0; i++)
                {
                    selectBossRoomStatus = false;
                    Vector3Int bossRoomPos = _PosArr[pos.z, pos.x]._CenterPosition + _Direction4[i];

                    if (PossibleArr(bossRoomPos))
                    {
                        if ((AroundRoomCount(bossRoomPos)<2)
                            && !_PosArr[bossRoomPos.z,bossRoomPos.x]._isValidRoom)
                        {
                            _PosArr[bossRoomPos.z, bossRoomPos.x]._RoomName        = "Boss";
                            _PosArr[bossRoomPos.z, bossRoomPos.x]._isValidRoom     = true;
                            _PosArr[bossRoomPos.z, bossRoomPos.x]._CenterPosition  = bossRoomPos;
                            _PosArr[bossRoomPos.z, bossRoomPos.x]._ParentPosition  = bossRoomPos;
                            _PosArr[bossRoomPos.z, bossRoomPos.x]._Distance        = _PosArr[pos.z,pos.x]._Distance+1;
                            _PosArr[bossRoomPos.z, bossRoomPos.x]._RoomName        = "Single";

                            _BossRoomPosition = bossRoomPos;
                            selectBossRoomStatus = true;

                            break;
                        }
                    }
                }
            }
        }        
    }

    //방의 배열을 초기화
    public void RealaseRoomPos()
    {
        for (int i = 0; i < (_MaxDistance*2); i++)
        {
            for (int j = 0; j < (_MaxDistance * 2); j++)
            {
                _PosArr[j, i] = new RoomInfo();
                _PosArr[j, i]._isValidRoom = false;
                _PosArr[j, i]._Distance = -1;
            }
        }
    }
    public void RealaseRoom()
    {
        RealaseRoomPos();
        _ValidRoomList.Clear();

        _CurrentRoomCount = 0;
    }
    //배열의 방들을 RoomController의 List로 변환
    public void SetUpPosition()
    {
        List<RoomInfo> roomsList = new List<RoomInfo>();

        for (int i = 0; i < (_MaxDistance*2); i++)
        {
            for (int j = 0; j < (_MaxDistance * 2); j++)
            {
                if (_PosArr[j,i]._isValidRoom)
                {
                    Vector3Int tmpArrayPosition = new Vector3Int(i, 0, j);

                    _PosArr[j, i] = SingleRoom(_PosArr[j, i], _PosArr[j, i]._RoomName);
                    _PosArr[j, i]._CenterPosition      = tmpArrayPosition                   - _StartRoomPosition;
                    _PosArr[j, i]._ParentPosition      = _PosArr[j,i]._ParentPosition      - _StartRoomPosition;
                    _PosArr[j, i]._MergeCenterPosition = _PosArr[j,i]._MergeCenterPosition - _StartRoomPosition;

                    roomsList.Add(_PosArr[j, i]);
                }
            }
        }
        _ValidRoomCount = _ValidRoomList.Count;

        for (int i = 0; i < roomsList.Count; i++)
        {
            //RoomController.Instance.l
        }
    }
    public RoomInfo SingleRoom(RoomInfo pos, string name)
    {
        RoomInfo single = pos;
        single._RoomID          = name + "(" + pos._CenterPosition.x + ", " + pos._CenterPosition.y + ", " + pos._CenterPosition.z + ")";
        single._RoomName        = name;
        single._CenterPosition  = pos._CenterPosition;
        single._CenterPosition  = pos._MergeCenterPosition;
        single._RoomType        = pos._RoomType;
        single._Distance        = pos._Distance;

        return single;
    }

    public int AroundRoomCount(Vector3Int pos)
    {
        int count = 0;
        //왼쪽
        if ((0 <= (pos.x - 1) && (pos.x - 1) < (_MaxDistance*2)))
        {
            if (_PosArr[pos.z,pos.x-1]._isValidRoom)
            {
                count += 1;
            }
        }
        //오른쪽
        if ((0 <= (pos.x + 1) && (pos.x + 1) < (_MaxDistance * 2)))
        {
            if (_PosArr[pos.z, pos.x - 1]._isValidRoom)
            {
                count += 1;
            }
        }
        //상단
        if ((0 <= (pos.z - 1) && (pos.x - 1) < (_MaxDistance * 2)))
        {
            if (_PosArr[pos.z, pos.x - 1]._isValidRoom)
            {
                count += 1;
            }
        }
        //하단
        if ((0 <= (pos.z + 1) && (pos.x + 1) < (_MaxDistance * 2)))
        {
            if (_PosArr[pos.z, pos.x - 1]._isValidRoom)
            {
                count += 1;
            }
        }
        return count;
    }
}
