using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data", order = int.MaxValue)]

public class UnitDefaultData : ScriptableObject
{
    // �̸�
    [SerializeField] private string _unitName;
    public string UnitName { get { return _unitName; } }

    // ���� ���ݷ�
    [SerializeField] private float _ad;
    public float AD { get { return _ad; } }

    // ���� ���ݷ�
    [SerializeField] private float _ap;
    public float AP { get { return _ap; } }
    
    [SerializeField] private float _as;
    public float AS { get { return _as; } }

    // ����
    [SerializeField] private float _df;
    public float DF { get { return _df; } }

    // ü��
    [SerializeField] private float _hp;
    public float HP { get { return _hp; } }

    // ����
    [SerializeField] private float _mp;
    public float MP { get { return _mp; } }

    // �̼�
    [SerializeField] private float _sp;
    public float SP { get { return _sp; } }
}
