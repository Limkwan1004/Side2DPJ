using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data", order = int.MaxValue)]

public class Unit_Data : ScriptableObject
{
    // �̸�
    [SerializeField] private string _unitName;
    public string UnitName { get { return _unitName; } }

    // ���ݷ�
    [SerializeField] private float _damage;
    public float Damage { get { return _damage; } }

    // �ִ�ü��
    [SerializeField] private float _maxHP;
    public float MaxHP { get { return _maxHP; } }

    // �̼�
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed { get { return _moveSpeed; } }

    // ������
    [SerializeField] private float _jumpForce;
    public float JumpForce { get { return _jumpForce; } }
}
