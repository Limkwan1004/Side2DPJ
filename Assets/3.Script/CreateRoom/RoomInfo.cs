using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class RoomInfo
{
    public string _RoomID;
    public string _RoomName;
    public string _RoomType;

    //현재 방 위치
    public Vector3Int _CenterPosition;
    //부모 방의 위치
    public Vector3Int _ParentPosition;
    //해당 방의 중앙 위치
    public Vector3Int _MergeCenterPosition;
    //해당 방의 설정 (true : 방, false : 빈방)
    public bool _isValidRoom;
    //시작 방에서 부터 해당 방까지의 거리
    public int _Distance;
}
