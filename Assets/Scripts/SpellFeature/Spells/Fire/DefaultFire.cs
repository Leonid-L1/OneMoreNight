using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultFire : Spell
{
    public override void Init()
    {
        Creator = new DefaultFireSpellCreator(this);
    }

    public override void Cast(SpellStats stats)
    {
        Debug.Log("DefaultFire, Force - " + stats.Force.CurrentStatLevel + " Length - " + stats.Length.CurrentStatLevel + " Width - " + stats.Width.CurrentStatLevel);
        base.Cast(stats);
    }
}
