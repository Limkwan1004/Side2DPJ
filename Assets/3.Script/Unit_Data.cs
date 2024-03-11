using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data", order = int.MaxValue)]

public class Unit_Data : ScriptableObject
{
    // 이름
    [SerializeField] private string _unitName;
    public string UnitName { get { return _unitName; } }

    // 공격력
    [SerializeField] private float _damage;
    public float Damage { get { return _damage; } }

    // 최대체력
    [SerializeField] private float _maxHP;
    public float MaxHP { get { return _maxHP; } }

    // 이속
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed { get { return _moveSpeed; } }

    // 점프력
    [SerializeField] private float _jumpForce;
    public float JumpForce { get { return _jumpForce; } }
}
