using System;
using BehaviorDesigner.Runtime;

public class SharedPlayer : SharedVariable<Player>
{
    public static implicit operator SharedPlayer(Player value) => new SharedPlayer { Value = value };
}

