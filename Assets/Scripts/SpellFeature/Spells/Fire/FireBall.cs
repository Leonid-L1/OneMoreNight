using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Spell
{
    public override void Init()
    {
        Creator = new FireBallCreator(this);
    }

    public override void Cast(SpellStats stats)
    {
        Debug.Log("FireBall, Force - " + stats.Force.CurrentStatLevel + " Length - " + stats.Length.CurrentStatLevel + " Width - " + stats.Width.CurrentStatLevel);
        base.Cast(stats);
    }
}
