using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellStats 
{
    public ForceStat Force { get; private set; }
    public LengthStat Length { get; private set; }
    public WidthStat Width { get; private set; }
    public EffectDurationStat EffectDuration { get; private set; }

    public void AddStat(SpellStat spellStat)
    {
        switch (spellStat)
        {
            case ForceStat:
                Force = spellStat as ForceStat;
                break;
            case LengthStat:
                Length = spellStat as LengthStat;
                break;
            case WidthStat:
                Width = spellStat as WidthStat;
                break;
            case EffectDurationStat:
                EffectDuration = spellStat as EffectDurationStat;
                break;
        }
    }
    public void Reset()
    {
        Force.Reset();
        Length.Reset();
        Width.Reset();
        EffectDuration.Reset();
    }
}
