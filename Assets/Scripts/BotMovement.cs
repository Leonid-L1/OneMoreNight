using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BotMovementInput))]
public class BotMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private float _diagonalSpeedMultiplier = 0.7f;
    private BotMovementInput _input;
    private Rigidbody2D _rigidbody;
    private Vector2 _direction = Vector2.zero;
    private bool _isMoving;
    private float _diagonalSpeed => _speed * _diagonalSpeedMultiplier;
    private bool _isDiagonalMovement => _direction.x != 0 && _direction.y != 0;

    public bool IsMoving => _isMoving;
    public Vector2 Direction => _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<BotMovementInput>();
    }

    private void FixedUpdate()
    {
        _direction = _input.MovementInput.normalized; 
        _isMoving = _input.MovementInput.normalized != Vector2.zero;
        Move();
    }

    public void Move()
    {   
        _rigidbody.isKinematic = _input.MovementInput.normalized == Vector2.zero;

        if (_isDiagonalMovement)
        {
            _direction.x *= _diagonalSpeedMultiplier;
            _direction.y *= _diagonalSpeedMultiplier;
        }
        _rigidbody.MovePosition(_rigidbody.position + _direction * _speed * Time.deltaTime);
    }
}
