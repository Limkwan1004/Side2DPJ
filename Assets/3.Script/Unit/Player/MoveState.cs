using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _speed = 5f;
    private void Awake()
    {
        TryGetComponent(out _rigidbody);
    }

    private void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //
        //_rigidbody.velocity = new Vector2(horizontal * _speed, vertical * _speed);
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }

    }
}
