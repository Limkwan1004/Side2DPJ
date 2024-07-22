using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DungeonCrawlerController : MonoBehaviour
{
    public static DungeonCrawlerController Instance = null;

    #region//4����
    public List<Vector3Int> _Direction4 = new List<Vector3Int>
    {
        new Vector3Int( 1, 0, 0),      //Right
        new Vector3Int(-1, 0, 0),      //Left
        new Vector3Int( 0, 0, 1),      //Top
        new Vector3Int( 0, 0,-1),      //Bottom

    };
    #endregion

    #region//8����
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

    #region 4���� ���� Pattern
    public Dictionary<int, List<Vector3Int>> _RightPattern = new Dictionary<int, List<Vector3Int>>
    {
        { 0, new List<Vector3Int> { new Vector3Int( 1, 0, 0), new Vector3Int( 2, 0, 0), new Vector3Int( 1, 0,-1), new Vector3Int(2, 0, 1) } },
        { 1, new List<Vector3Int> { new Vector3Int( 1, 0, 0), new Vector3Int( 2, 0, 0), new Vector3Int( 2, 0,-1) } }, // ��
        { 2, new List<Vector3Int> { new Vector3Int( 1, 0, 0), new Vector3Int( 2, 0, 0), new Vector3Int( 2, 0, 1) } }, // ��
        { 3, new List<Vector3Int> { new Vector3Int( 1, 0, 0), new Vector3Int( 2, 0, 0)                          } }, // ������ --
        { 4, new List<Vector3Int> { new Vector3Int( 1, 0, 0), new Vector3Int( 1, 0, 1)                          } }, // ������ --
        { 5, new List<Vector3Int> { new Vector3Int( 1, 0, 0), new Vector3Int( 1, 0,-1)                          } }, // ������ --
        { 6, new List<Vector3Int> { new Vector3Int( 1, 0, 0)                                                    } }, // ������ --
    };
    public Dictionary<int, List<Vector3Int>> _LeftPattern = new Dictionary<int, List<Vector3Int>>
    {
        { 0, new List<Vector3Int> { new Vector3Int(-1, 0, 0), new Vector3Int(-2, 0, 0), new Vector3Int(-1, 0,-1), new Vector3Int(-2, 0,-1) } },
        { 1, new List<Vector3Int> { new Vector3Int(-1, 0, 0), new Vector3Int(-2, 0, 0), new Vector3Int(-2, 0,-1) } }, // ��
        { 2, new List<Vector3Int> { new Vector3Int(-1, 0, 0), new Vector3Int(-2, 0, 0), new Vector3Int(-2, 0, 1) } }, // ��
        { 3, new List<Vector3Int> { new Vector3Int(-1, 0, 0), new Vector3Int(-2, 0, 0)                          } }, // ���� --
        { 4, new List<Vector3Int> { new Vector3Int(-1, 0, 0), new Vector3Int(-1, 0,-1)                          } }, // ���� --
        { 5, new List<Vector3Int> { new Vector3Int(-1, 0, 0), new Vector3Int(-1, 0, 1)                          } }, // ���� --
        { 6, new List<Vector3Int> { new Vector3Int(-1, 0, 0)                                                    } }, // ���� --
    };
    public Dictionary<int, List<Vector3Int>> _TopPattern = new Dictionary<int, List<Vector3Int>>
    {
        { 0, new List<Vector3Int> { new Vector3Int( 0, 0,-1), new Vector3Int( 0, 0,-2), new Vector3Int(-1, 0,-1), new Vector3Int(-1, 0,-2) } },
        { 1, new List<Vector3Int> { new Vector3Int( 0, 0,-1), new Vector3Int( 0, 0,-2), new Vector3Int( 1, 0,-2) } }, // ��
        { 2, new List<Vector3Int> { new Vector3Int( 0, 0,-1), new Vector3Int( 0, 0,-2), new Vector3Int(-1, 0,-2) } }, // ��
        { 3, new List<Vector3Int> { new Vector3Int( 0, 0,-1), new Vector3Int( 0, 0,-2)                          } }, // �� |
        { 4, new List<Vector3Int> { new Vector3Int( 0, 0,-1), new Vector3Int( 1, 0,-1)                          } }, // �� |
        { 5, new List<Vector3Int> { new Vector3Int( 0, 0,-1), new Vector3Int(-1, 0,-1)                          } }, // �� |
        { 6, new List<Vector3Int> { new Vector3Int( 0, 0,-1)                                                    } }, // �� |
    };
    public Dictionary<int, List<Vector3Int>> _BottomPattern = new Dictionary<int, List<Vector3Int>>
    {
        { 0, new List<Vector3Int> { new Vector3Int( 0, 0, 1), new Vector3Int(-1, 0, 1), new Vector3Int( 0, 0, 2), new Vector3Int(-1, 0, 2) } },
        { 1, new List<Vector3Int> { new Vector3Int( 0, 0, 1), new Vector3Int( 0, 0, 2), new Vector3Int(-1, 0, 2) } }, // ��
        { 2, new List<Vector3Int> { new Vector3Int( 0, 0, 1), new Vector3Int( 0, 0, 2), new Vector3Int( 1, 0, 2) } }, // ��
        { 3, new List<Vector3Int> { new Vector3Int( 0, 0, 1), new Vector3Int( 0, 0, 2)                          } }, // �Ʒ� |
        { 4, new List<Vector3Int> { new Vector3Int( 0, 0, 1), new Vector3Int(-1, 0, 1)                          } }, // �Ʒ� |
        { 5, new List<Vector3Int> { new Vector3Int( 0, 0, 1), new Vector3Int( 1, 0, 1)                          } }, // �Ʒ� |
        { 6, new List<Vector3Int> { new Vector3Int( 0, 0, 1)                                                    } }, // �Ʒ� |
    };

    #endregion

    //��ȿ�� ���� ���� ����Ʈ
    public List<RoomInfo> _ValidRoomList = new List<RoomInfo>();

    public int _MinRoomCount = 15;          //�ּ� �� ����
    public int _MaxRoomCount = 20;          //�ִ� �� ����
    public int _CurrentRoomCount = 0;       //���� �� ����
    public int _MaxDistance = 5;            //�ִ� �Ÿ� ����

    public int _ValidRoomCount = 0;         //��ȿ�� �� ����

    public Vector3Int _StartRoomPosition;   //���� ��ġ
    public Vector3Int _BossRoomPosition;    //������ ��ġ

    public RoomInfo[,] _PosArr = new RoomInfo[10, 10]; //�� ��ǥ�� ���� 2����

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

        //�迭 ReSize
        _PosArr = (RoomInfo[,])ResizeArray(_PosArr, new int[] { (_MaxDistance * 2), (_MaxDistance * 2) });

        int x = UnityEngine.Random.Range(0, _MaxDistance) + (_MaxDistance);     //�ִ� ũ�� X ��ǥ
        int z = UnityEngine.Random.Range(0, _MaxDistance) + (_MaxDistance);     //�ִ� ũ�� Y ��ǥ

        _StartRoomPosition = new Vector3Int(x, 0, z);                           //���� ��ǥ

        //_PossArr[_StartRoomPosition.z,_StartRoomPosition.x] =
        _PosArr[_StartRoomPosition.z, _StartRoomPosition.x]._Distance = 0;
        _CurrentRoomCount++;
    }
    
    public RoomInfo AddSingleRoom(RoomInfo room, Vector3Int pos, string name)
    {   //���� ���� �Է�
        RoomInfo single = room;
        single._RoomID = name+ "(" + pos.x + ", " + pos.y + ", " + pos.z + ")";
        single._RoomName = name;
        single._CenterPosition = pos;
        single._ParentPosition = pos;
        single._RoomType = "Single";
        single._isValidRoom = true;
        return single;
    }

    //���� ������ �ּ�, �ִ� ũ�⿡ �������� üũ
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
        //�� ���� ũ�⸦ ���Ͽ� �� ��ȯ
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

    //���� �迭�� �ʱ�ȭ
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
    //�迭�� ����� RoomController�� List�� ��ȯ
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
        //����
        if ((0 <= (pos.x - 1) && (pos.x - 1) < (_MaxDistance*2)))
        {
            if (_PosArr[pos.z,pos.x-1]._isValidRoom)
            {
                count += 1;
            }
        }
        //������
        if ((0 <= (pos.x + 1) && (pos.x + 1) < (_MaxDistance * 2)))
        {
            if (_PosArr[pos.z, pos.x - 1]._isValidRoom)
            {
                count += 1;
            }
        }
        //���
        if ((0 <= (pos.z - 1) && (pos.x - 1) < (_MaxDistance * 2)))
        {
            if (_PosArr[pos.z, pos.x - 1]._isValidRoom)
            {
                count += 1;
            }
        }
        //�ϴ�
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
