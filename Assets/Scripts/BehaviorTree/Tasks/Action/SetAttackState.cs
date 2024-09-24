using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetAttackState <TObject, TSharedObject> : Action where TObject : Component where TSharedObject : SharedVariable < TObject>
{ 
    public SharedBool IsStart;

    public SharedBotAnimationController _animationController;
    public TSharedObject Target;

    public override void OnAwake()
    {
        if (IsStart.Value)
        {
            Vector2 direction = Target.Value.transform.position - transform.position;
            _animationController.Value.SetAttack(direction.normalized);
        }
        else
        {

        }
    }
}
