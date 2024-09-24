using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTornadoCreator : SpellCreator
{
    public FireTornadoCreator(FireTornado spell) => Spell = spell;
    
    public override void HandleStats(SpellStats stats)
    {   
        if (stats.Length.CurrentStatLevel >= 2 && stats.Width.CurrentStatLevel >= 2)
            Cast(stats);
        else
            NextSuccessor.HandleStats(stats);
    }
}
