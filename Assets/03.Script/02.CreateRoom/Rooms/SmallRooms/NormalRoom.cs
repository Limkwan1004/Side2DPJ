using DefineManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRoom : RoomsDefine
{
    protected override void InitializeRoom()
    {
        _RoomInfomaion = RoomInfo.NormalRoom;
    }
}
