using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class RoomInfo
{
    public string _RoomID;
    public string _RoomName;
    public string _RoomType;

    //���� �� ��ġ
    public Vector3 _CenterPosition;
    //�θ� ���� ��ġ
    public Vector3 _ParentPosition;
    //�ش� ���� �߾� ��ġ
    public Vector3 _MergeCenterPosition;
    //�ش� ���� ���� (true : ��, false : ���)
    public bool _isValidRoom;
    //���� �濡�� ���� �ش� ������� �Ÿ�
    public int _Distance;
}
