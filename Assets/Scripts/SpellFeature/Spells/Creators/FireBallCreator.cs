using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCreator : SpellCreator
{   
    public FireBallCreator(FireBall fireBall)=> Spell = fireBall;
    public override void HandleStats(SpellStats stats)
    {
        if (stats.Length.CurrentStatLevel >= 2)
            Cast(stats);
        else
            NextSuccessor.HandleStats(stats);
    }
}
