using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data", order = int.MaxValue)]

public class UnitData : ScriptableObject
{
    // �̸� Name
    [SerializeField] private string _name;
    public string NAME { get { return _name; } }

    // ���� ���ݷ� Physical Attack
    [SerializeField] private float _psa;
    public float PSA { get { return _psa; } }

    // ���� ���ݷ� Magical Attack
    [SerializeField] private float _mga;
    public float MGA { get { return _mga; } }

    // ���ݼӵ� Attack Speed
    [SerializeField] private float _ats;
    public float ATS { get { return _ats; } }

    // ġ��Ÿ Critical
    [SerializeField] private float _crt;
    public float CRT { get { return _crt; } }

    // ȸ���� Avoidability
    [SerializeField] private float _avd;
    public float AVD { get { return _avd; } }

    // ���߷� Accuracy
    [SerializeField] private float _acc;
    public float ACC { get { return _acc; } }

    // ���� Defense
    [SerializeField] private float _def;
    public float DEF { get { return _def; } }

    // ü�� Health
    [SerializeField] private float _hp;
    public float HP { get { return _hp; } }

    // ���� Mana
    [SerializeField] private float _mp;
    public float MP { get { return _mp; } }

    // �̵��ӵ� Speed
    [SerializeField] private float _sp;
    public float SP { get { return _sp; } }

    // ���� Level
    [SerializeField] private int _lv;
    public int LV { get { return _lv; } }
}
