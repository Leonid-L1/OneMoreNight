using UnityEngine;
public class FireWave : Spell
{
    public override void Init()
    {
        Creator = new FireWaveCreator(this);
    }

    public override void Cast(SpellStats stats)
    {
        Debug.Log("FireWave, Force - " + stats.Force.CurrentStatLevel + " Length - " + stats.Length.CurrentStatLevel + " Width - " + stats.Width.CurrentStatLevel);
        base.Cast(stats);
    }
}

