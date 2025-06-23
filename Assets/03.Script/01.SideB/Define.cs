using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefineManager
{
    public enum RoomInfo
    {
        StartRoom = 0,
        NormalRoom,
        RoomA,
        RoomB,
        RoomC,
        LargeRoomA,
        LargeRoomB,
        LargeRoomC,
        LargeRoomD,
        BossRoomA,
        BossRoomB,
        StoreRoom,
        ChestRoom = 12,
    }

    public enum DoorInfo
    {
        TopDoor,
        BottomDoor,
        LeftDoor,
        RightDoor,
    }

    public class Define
    {

    }

    public struct UnitDefine
    {
        public enum UnitState
        {
            None = 0,
            Idle = 1,
            Hit = 2,
            Die = 3,

        }

        public class UnitInfo
        {
            public string _Name;
            public float _Psa;
            public float _Mga;
            public float _Ats;

            private float _crt;
            public float _Crt
            {
                get { return _crt; }
                set { _crt = Mathf.Clamp(value, 0, 100); }
            }
            public float _Avd;
            public float _Acc;
            public float _Def;
            public float _MaxHp;
            public float _MaxMp;
            public float _Sp;

            private int _lv;
            public int _Lv
            {
                get { return _lv; }
                set { _lv = Mathf.Clamp(value, 1, 60); }
            }
            public UnitInfo(string name, float psa, float mga, float ats, float crt, float avd, float acc, float def, float hp, float mp, float sp, int lv)
            {
                _Name = name;
                _Psa = psa;
                _Mga = mga;
                _Ats = ats;
                _Crt = crt;
                _Avd = avd;
                _Acc = acc;
                _Def = def;
                _MaxHp = hp;
                _MaxMp = mp;
                _Sp = sp;
                _Lv = lv;
            }
        }
    }
}


