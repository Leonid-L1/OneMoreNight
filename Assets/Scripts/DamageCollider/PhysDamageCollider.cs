using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysDamageCollider : DamageCollider
{
    private Coroutine _currentCoroutine;

    public override void CreateCollider(Vector2 direction)
    {
        if (_currentCoroutine == null)
            _currentCoroutine = StartCoroutine(SetCollider(direction));
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            //player.GetDamage(_damage);
            Debug.Log("PlayerHit");
            DisableCollider();
        }
    }

    protected override void EnableCollider(Vector2 direction)
    {
        if (TriggerCollider.enabled == true)
            return;
        TriggerCollider.offset = direction;
        TriggerCollider.enabled = true;
    }

    protected override void DisableCollider()
    {
        TriggerCollider.offset = Vector2.zero;
        TriggerCollider.enabled = false;
    }

    private IEnumerator SetCollider(Vector2 direction)
    {
        yield return new WaitForSeconds(DelayBeforeCreating);
        EnableCollider(SetColliderDirection(direction));
        yield return new WaitForSeconds(ColliderLifeTime);
        DisableCollider();
        _currentCoroutine = null;
    }
}
    

