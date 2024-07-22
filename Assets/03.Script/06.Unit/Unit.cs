using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private UnitData _unitData = new UnitData();

    private UnitState _unitState;


    private float _hp;
    public float _Hp
    {
        get { return _hp; }
        set
        {
            _hp = value;
            if (_hp <= 0)
            {
                // Á×´Â ÇÔ¼ö
            }
        }
    }


    public virtual void ChangeState(UnitState unitState)
    {
        _unitState = unitState;

    }

    protected void SetData()
    {
        UnitInfo _unitInfo = new UnitInfo(_unitData.NAME, _unitData.PSA, _unitData.MGA, _unitData.ATS, _unitData.CRT, _unitData.AVD, _unitData.ACC,
            _unitData.DEF, _unitData.HP, _unitData.MP, _unitData.SP, _unitData.LV);
    }


}
