using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    left,
    right,
    top,
    bottom,
}
public class Door : MonoBehaviour
{
    public GameObject _NextRoom;
    public Door _SideDoor;
    public DoorType _DoorType;
    public Transform _DoorPos;
    public bool isUpdate = false;

    public void SetNextRoom(GameObject nextRoom)
    {
        _NextRoom = nextRoom;
    }

}
