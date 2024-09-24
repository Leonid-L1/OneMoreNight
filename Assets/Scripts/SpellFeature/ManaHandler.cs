using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaHandler : MonoBehaviour
{
    [SerializeField] private float _maxMana;

    private static float SecondLevelModifier = 1.2f;
    private static float ThirdLevelModeifier = 1.5f;
    private static int DefaultManacost = 20;
    private Dictionary<int, float > _modifiersByLevel = new Dictionary<int, float>() { {1,1 }, {2, SecondLevelModifier }, {3, ThirdLevelModeifier } };
    private float _currentMana;

    private void Start()
    {
        _currentMana = _maxMana;
    }

    public bool TrySpendMana(SpellStat spellstat)
    {
        var currentManacost = DefaultManacost * _modifiersByLevel[spellstat.CurrentStatLevel + 1];

        if (currentManacost <= _currentMana)
        {
            _currentMana -= currentManacost;
            //Debug.Log(_currentMana);
            return true;
        }         
        else 
            return false;
    }

    public void TrySpendMana()
    {

    }
}
