using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected Unit _unit;

    private void Start()
    {
        TryGetComponent(out _unit);
    }

    public abstract void Act();
}
