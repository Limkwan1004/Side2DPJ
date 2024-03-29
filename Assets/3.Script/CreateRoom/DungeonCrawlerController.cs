using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCrawlerController : MonoBehaviour
{

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

    public RoomInfo[,] _PossArr = new RoomInfo[10, 10]; //�� ��ǥ�� ���� 2����

    public void CreatedRoom()
    {
        _PossArr = (RoomInfo[,])ResizeArray(_PossArr, new int[] { (_MaxDistance * 2), (_MaxDistance * 2) });

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
}
