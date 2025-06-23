using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data", order = int.MaxValue)]

public class UnitData : ScriptableObject
{
    // 이름 Name
    [SerializeField] private string _name;
    public string NAME { get { return _name; } }

    // 물리 공격력 Physical Attack
    [SerializeField] private float _physicalAttack;
    public float PHYSICALATTACK { get { return _physicalAttack; } }

    // 마법 공격력 Magical Attack
    [SerializeField] private float _magicalAttack;
    public float MAGICALATTACK { get { return _magicalAttack; } }

    // 공격속도 Attack Speed
    [SerializeField] private float _attackSpeed;
    public float ATTACKSPEED { get { return _attackSpeed; } }

    // 치명타 Critical
    [SerializeField] private float _critical;
    public float CRITICAL { get { return _critical; } }

    // 회피율 Avoidability
    [SerializeField] private float _avoid;
    public float AVOID { get { return _avoid; } }

    // 명중률 Accuracy
    [SerializeField] private float _accuracy;
    public float ACCURACY { get { return _accuracy; } }

    // 방어력 Defense
    [SerializeField] private float _defense;
    public float DEFENSE { get { return _defense; } }

    // 체력 Health
    [SerializeField] private float _hp;
    public float HP { get { return _hp; } }

    // 마나 Mana
    [SerializeField] private float _mp;
    public float MP { get { return _mp; } }

    // 이동속도 Speed
    [SerializeField] private float _speed;
    public float SPEED { get { return _speed; } }

    // 레벨 Level
    [SerializeField] private int _level;
    public int LEVEL { get { return _level; } }
}
