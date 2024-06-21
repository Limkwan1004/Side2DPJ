using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected Unit _unit;

    public int _requirementLevel;    // 요구레벨
    public int _cost;                // 소모자원
    public float _coolTime;          // 쿨타임
    public int _minLevel;            // 스킬최소레벨
    public int _maxLevel;            // 스킬최대레벨

    protected enum Job
    {
        // 1전사, 2궁수, 3법사, 4도적
        Warrior = 1,
        Archer = 2,
        Wizard = 3,
        Assassin = 4,
    }

    protected enum SkillType
    {
        // 1액티브, 2패시브
        Active = 1,
        Passive = 2,
    }

    protected enum SkillEffect
    {
        // 1방깎, 2둔화, 3기절, 4공격/방어력증가, 6공격/이동속도증가,
        // 7HP/MP재생증가, 8회피/명중률증가, 9방어력무시
        DefensiveCut = 1,
        Slow = 2,
        Stun = 3,
        increasedDFAD = 4,


    }

    protected enum TargetType
    {
        // 1단일, 2멀티
        Single = 1,
        Multi = 2,
    }

    private void Start()
    {
        TryGetComponent(out _unit);
    }

    public abstract void Act();
}
