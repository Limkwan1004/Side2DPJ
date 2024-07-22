using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data", order = int.MaxValue)]

public class UnitDefaultData : ScriptableObject
{
    // 이름
    [SerializeField] private string _unitName;
    public string UnitName { get { return _unitName; } }

    // 물리 공격력
    [SerializeField] private float _ad;
    public float AD { get { return _ad; } }

    // 마법 공격력
    [SerializeField] private float _ap;
    public float AP { get { return _ap; } }
    
    [SerializeField] private float _as;
    public float AS { get { return _as; } }

    // 방어력
    [SerializeField] private float _df;
    public float DF { get { return _df; } }

    // 체력
    [SerializeField] private float _hp;
    public float HP { get { return _hp; } }

    // 마나
    [SerializeField] private float _mp;
    public float MP { get { return _mp; } }

    // 이속
    [SerializeField] private float _sp;
    public float SP { get { return _sp; } }
}
