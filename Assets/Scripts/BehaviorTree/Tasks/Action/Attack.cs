using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Attack<TObject, TSharedObject> : Action where TObject : Component where TSharedObject : SharedVariable<TObject>
{
    public SharedBotAnimationController AnimationController;
    public TSharedObject Target;
    public SharedDamageCollider DamageCollider;

    public override TaskStatus OnUpdate()
    {
        Vector2 direction = Target.Value.transform.position - transform.position;
        direction.Normalize();
        AnimationController.Value.SetAttack(direction);
        DamageCollider.Value.CreateCollider(direction);

        return TaskStatus.Success;
    }
}
