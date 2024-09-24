using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetMovementInput : Action 
{
    public SharedBotMovementInput SelfInput;
    public SharedVector2 Direction;

    public override TaskStatus OnUpdate()
    {
        SelfInput.Value.MovementInput = Vector2.zero;
        return TaskStatus.Success;
    }
}
