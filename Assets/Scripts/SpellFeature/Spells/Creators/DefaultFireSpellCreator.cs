using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultFireSpellCreator : SpellCreator
{
    public DefaultFireSpellCreator(DefaultFire defaultFire) => Spell = defaultFire;

    public override void HandleStats(SpellStats stats)
    {
        Cast(stats);
    }
}
