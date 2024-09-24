using System;
using BehaviorDesigner.Runtime;

public class SharedBotAnimationController : SharedVariable<BotAnimationController>
{
    public static implicit operator SharedBotAnimationController(BotAnimationController value) => new SharedBotAnimationController { Value = value };
}

