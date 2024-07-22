using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallType
{
    left,
    right,
    top,
    bottom
}
public class Wall : MonoBehaviour
{
    public WallType _WallType;
    public Transform _WallPos;
    public bool isSetUp = false;
    public bool isUpdate = false;
}
