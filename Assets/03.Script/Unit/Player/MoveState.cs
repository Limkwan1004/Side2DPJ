using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private Rigidbody2D _rigidbody;
    private float _speed = 3f;

    private void Awake()
    {
        TryGetComponent(out _rigidbody);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
    }
}
