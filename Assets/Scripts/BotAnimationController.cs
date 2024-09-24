using UnityEngine;

[RequireComponent(typeof(BotMovement))]
[RequireComponent(typeof(Animator))]

public class BotAnimationController : MonoBehaviour
{
    private BotMovement _movement;
    private Animator _animator;

    private void Start()
    {   
        _movement = GetComponent<BotMovement>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()=> _animator.SetBool("IsMoving", _movement.IsMoving);

    public void SetAttack(Vector2 direction)
    {
        _animator.SetTrigger("Attack");
        _animator.SetFloat("AttackHorizontal", direction.x);
        _animator.SetFloat("AttackVertical", direction.y);
    }

    public void SetDirection(Vector2 direction)
    {
        _animator.SetFloat("Horizontal", direction.x);
        _animator.SetFloat("Vertical", direction.y);       
    }
}
