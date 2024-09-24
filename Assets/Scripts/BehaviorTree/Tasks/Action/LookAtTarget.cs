using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class LookAtTarget<TObject, TSharedObject> : Action where TObject : Component where TSharedObject : SharedVariable<TObject>
{   
    public SharedBotAnimationController _animationController;
    public TSharedObject Target;

    public override TaskStatus OnUpdate()
    {
        Vector2 direction = Target.Value.transform.position - transform.position;
        _animationController.Value.SetDirection(direction.normalized);

        return TaskStatus.Running;
    }
}
