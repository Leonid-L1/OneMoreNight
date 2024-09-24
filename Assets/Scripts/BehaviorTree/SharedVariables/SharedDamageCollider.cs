using BehaviorDesigner.Runtime;

public class SharedDamageCollider : SharedVariable<DamageCollider>
{
    public static implicit operator SharedDamageCollider(DamageCollider value) => new SharedDamageCollider { Value = value };
}
