using System.Collections;
using UnityEngine;

public abstract class DamageCollider : MonoBehaviour
{
    [SerializeField] protected Collider2D TriggerCollider;
    [SerializeField] private  float _delayBeforeCreating;
    [SerializeField] private int _damage;
    [SerializeField] private Vector2 _offsetTop;
    [SerializeField] private Vector2 _offsetBottom;
    [SerializeField] private Vector2 _offsetRight;
    [SerializeField] private Vector2 _offsetLeft;

    private float _colliderLifeTime = 0.15f;
    protected float DelayBeforeCreating => _delayBeforeCreating;
    protected float ColliderLifeTime => _colliderLifeTime;
    protected int Damage => _damage;

    private void Start() => DisableCollider();

    public abstract void CreateCollider(Vector2 direction);   

    protected abstract void EnableCollider(Vector2 direction);

    protected abstract void DisableCollider();
    
    protected abstract void OnTriggerEnter2D(Collider2D collision);

    protected Vector2 SetColliderDirection(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            return (direction.x > 0) ? _offsetRight : _offsetLeft;
        else
            return (direction.y > 0) ? _offsetTop : _offsetBottom;
    }
}
