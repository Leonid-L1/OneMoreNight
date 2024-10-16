using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEditor;
using UnityEngine;

public class Chase<TObject, TSharedObject> : Action where TObject : Component where TSharedObject : SharedVariable<TObject>
{
    public SharedBotMovementInput SelfInput;
    public TSharedObject Target;

    public override TaskStatus OnUpdate()
    {
        //Vector2 direction = Target.Value.transform.position - transform.position;

        //SelfInput.Value.MovementInput = direction;
        SelfInput.Value.MovementInput = Target.Value.transform.position;

        return TaskStatus.Running;
    }
}

