using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData
{
    private string _Name;
    private float _HP;
    private float _MP;
    private float _AD;
    private float _AP;
    private float _AS;
    private float _DF;
    private float _SP;


}

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitDefaultData _defaultData;
    public UnitData unitData;

    private void Awake()
    {

    }

}
