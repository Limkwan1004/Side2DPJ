using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data", order = int.MaxValue)]

public class UnitData : ScriptableObject
{
    // �̸� Name
    [SerializeField] private string _name;
    public string NAME { get { return _name; } }

    // ���� ���ݷ� Physical Attack
    [SerializeField] private float _physicalAttack;
    public float PHYSICALATTACK { get { return _physicalAttack; } }

    // ���� ���ݷ� Magical Attack
    [SerializeField] private float _magicalAttack;
    public float MAGICALATTACK { get { return _magicalAttack; } }

    // ���ݼӵ� Attack Speed
    [SerializeField] private float _attackSpeed;
    public float ATTACKSPEED { get { return _attackSpeed; } }

    // ġ��Ÿ Critical
    [SerializeField] private float _critical;
    public float CRITICAL { get { return _critical; } }

    // ȸ���� Avoidability
    [SerializeField] private float _avoid;
    public float AVOID { get { return _avoid; } }

    // ���߷� Accuracy
    [SerializeField] private float _accuracy;
    public float ACCURACY { get { return _accuracy; } }

    // ���� Defense
    [SerializeField] private float _defense;
    public float DEFENSE { get { return _defense; } }

    // ü�� Health
    [SerializeField] private float _hp;
    public float HP { get { return _hp; } }

    // ���� Mana
    [SerializeField] private float _mp;
    public float MP { get { return _mp; } }

    // �̵��ӵ� Speed
    [SerializeField] private float _speed;
    public float SPEED { get { return _speed; } }

    // ���� Level
    [SerializeField] private int _level;
    public int LEVEL { get { return _level; } }
}
