using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows;

[RequireComponent(typeof(BotMovementInput))]

public class BotMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private BotMovementInput _input;
    private NavMeshAgent _selfAgent;
    private bool _isMoving;
    public bool IsMoving => _isMoving;

    private void Awake()
    {
        _input = GetComponent<BotMovementInput>();
        _selfAgent = GetComponent<NavMeshAgent>();
        _selfAgent.speed = _speed;
        _selfAgent.updateRotation = false;
        _selfAgent.updateUpAxis = false;
    }

    private void Update()
    {
        _isMoving = _selfAgent.remainingDistance != 0;
        _selfAgent.SetDestination(_input.MovementInput);
    }
}
