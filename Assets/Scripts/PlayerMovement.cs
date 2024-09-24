using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private Vector2 _direction;

    private float _diagonalSpeedMultiplier = 0.7f;
    private bool _isDiagonalMovement => _direction.x != 0 && _direction.y != 0;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Horizontal", _direction.x);
        _animator.SetFloat("Vertical", _direction.y);
        _animator.SetFloat("Speed", _direction.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if (_isDiagonalMovement)
        {         
            _direction.x *= _diagonalSpeedMultiplier;
            _direction.y *= _diagonalSpeedMultiplier;
        }

        _rigidBody.MovePosition(_rigidBody.position + _direction * _moveSpeed * Time.deltaTime);
    }
}
