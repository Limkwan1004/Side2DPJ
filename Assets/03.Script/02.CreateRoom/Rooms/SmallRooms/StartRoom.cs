using DefineManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom : RoomsDefine
{
    protected override void InitializeRoom()
    {
        _RoomInfomaion = RoomInfo.StartRoom;
    }
}
