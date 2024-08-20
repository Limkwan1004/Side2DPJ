using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineManager;

public abstract class RoomsDefine : MonoBehaviour
{
    public RoomInfo _RoomInfomaion;

    private void Start()
    {
        
    }

    protected abstract void InitializeRoom();
    
}
