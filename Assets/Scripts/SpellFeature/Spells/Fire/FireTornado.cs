using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTornado : Spell
{
    public override void Init()
    {
        Creator = new FireTornadoCreator(this);
    }

    public override void Cast(SpellStats stats)
    {
        Debug.Log("FireTornado, Force - " + stats.Force.CurrentStatLevel + " Length - " + stats.Length.CurrentStatLevel + " Width - " + stats.Width.CurrentStatLevel);
        base.Cast(stats);
    }
}
