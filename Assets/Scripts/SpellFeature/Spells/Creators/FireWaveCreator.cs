using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWaveCreator : SpellCreator
{   
    public FireWaveCreator(FireWave fireWave) => Spell = fireWave;

    public override void HandleStats(SpellStats stats)
    { 
        if (stats.Width.CurrentStatLevel >= 2)
            Cast(stats);
        else
            NextSuccessor.HandleStats(stats);
    }
}
