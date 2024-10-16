using UnityEngine;
public abstract class SpellCreator
{
    public SpellCreator NextSuccessor { get; set; }

    protected Spell Spell;
    public abstract void HandleStats(SpellStats stats);

    public void CheckStats(SpellStats stats)
    {
        Debug.Log(stats.Force == null);
        Debug.Log(stats.Length == null);
        Debug.Log(stats.Width == null);
        Debug.Log(stats.EffectDuration == null);
    }

    protected void ResetStats(SpellStats stats)
    {
        stats.Force.Reset();
        stats.Length.Reset();
        stats.Width.Reset();
        stats.EffectDuration.Reset();
    }

    public void Cast(SpellStats stats)
    {
        Spell.Cast(stats);
        //ResetStats(stats);
    }
}
