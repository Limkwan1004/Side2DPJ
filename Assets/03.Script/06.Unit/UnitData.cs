using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data", order = int.MaxValue)]

public class UnitData : ScriptableObject
{
    // 이름 Name
    [SerializeField] private string _name;
    public string NAME { get { return _name; } }

    // 물리 공격력 Physical Attack
    [SerializeField] private float _psa;
    public float PSA { get { return _psa; } }

    // 마법 공격력 Magical Attack
    [SerializeField] private float _mga;
    public float MGA { get { return _mga; } }

    // 공격속도 Attack Speed
    [SerializeField] private float _ats;
    public float ATS { get { return _ats; } }

    // 치명타 Critical
    [SerializeField] private float _crt;
    public float CRT { get { return _crt; } }

    // 회피율 Avoidability
    [SerializeField] private float _avd;
    public float AVD { get { return _avd; } }

    // 명중률 Accuracy
    [SerializeField] private float _acc;
    public float ACC { get { return _acc; } }

    // 방어력 Defense
    [SerializeField] private float _def;
    public float DEF { get { return _def; } }

    // 체력 Health
    [SerializeField] private float _hp;
    public float HP { get { return _hp; } }

    // 마나 Mana
    [SerializeField] private float _mp;
    public float MP { get { return _mp; } }

    // 이동속도 Speed
    [SerializeField] private float _sp;
    public float SP { get { return _sp; } }

    // 레벨 Level
    [SerializeField] private int _lv;
    public int LV { get { return _lv; } }
}
