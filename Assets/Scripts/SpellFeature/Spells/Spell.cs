using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public SpellCreator Creator;

    public abstract void Init();

    public virtual void Cast(SpellStats stats)
    {
        stats.Reset();
    }
}
