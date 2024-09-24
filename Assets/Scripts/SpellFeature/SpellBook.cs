using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    [SerializeField] private List<Spell> _spells = new List<Spell>();
    
    private void Start()
    {
        foreach (var spell in _spells)
            spell.Init();

        for (int i = 0; i < _spells.Count - 1; i++)
            _spells[i].Creator.NextSuccessor = _spells[i + 1].Creator;
    }

    public void Cast(SpellStats stats) => _spells[0].Creator.HandleStats(stats);
}
