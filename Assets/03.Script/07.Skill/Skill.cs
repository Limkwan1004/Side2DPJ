using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected Unit _unit;

    public int _requirementLevel;    // �䱸����
    public int _cost;                // �Ҹ��ڿ�
    public float _coolTime;          // ��Ÿ��
    public int _minLevel;            // ��ų�ּҷ���
    public int _maxLevel;            // ��ų�ִ뷹��

    protected enum Job
    {
        // 1����, 2�ü�, 3����, 4����
        Warrior = 1,
        Archer = 2,
        Wizard = 3,
        Assassin = 4,
    }

    protected enum SkillType
    {
        // 1��Ƽ��, 2�нú�
        Active = 1,
        Passive = 2,
    }

    protected enum SkillEffect
    {
        // 1���, 2��ȭ, 3����, 4����/��������, 6����/�̵��ӵ�����,
        // 7HP/MP�������, 8ȸ��/���߷�����, 9���¹���
        DefensiveCut = 1,
        Slow = 2,
        Stun = 3,
        increasedDFAD = 4,


    }

    protected enum TargetType
    {
        // 1����, 2��Ƽ
        Single = 1,
        Multi = 2,
    }

    private void Start()
    {
        TryGetComponent(out _unit);
    }

    public abstract void Act();
}
