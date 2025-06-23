using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineManager;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private UnitData _unitData = new UnitData();

    private UnitDefine.UnitState _unitState = UnitDefine.UnitState.Idle;


    private float _hp;
    public float _Hp
    {
        get { return _hp; }
        set
        {
            _hp = value;
            if (_hp <= 0)
            {
                ChangeState(UnitDefine.UnitState.Die);
            }
        }
    }

    private void Start()
    {
        SetUnitData();
    }

    public virtual void ChangeState(UnitDefine.UnitState unitState)
    {
        if (unitState == _unitState)
            return;

        switch (_unitState)
        {
            case UnitDefine.UnitState.None:
                break;
            case UnitDefine.UnitState.Idle:
                break;
            case UnitDefine.UnitState.Hit:
                break;
            case UnitDefine.UnitState.Die:
                break;
        }

    }

    protected void SetUnitData()
    {
        UnitDefine.UnitInfo _unitInfo = new UnitDefine.UnitInfo(_unitData.NAME, _unitData.PHYSICALATTACK, _unitData.MAGICALATTACK, _unitData.ATTACKSPEED, _unitData.CRITICAL,
            _unitData.AVOID, _unitData.ACCURACY, _unitData.DEFENSE, _unitData.HP, _unitData.MP, _unitData.SPEED, _unitData.LEVEL);
    }


}
