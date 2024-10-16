using System.Collections.Generic;
using UnityEngine;

public class ManaHandler : MonoBehaviour
{
    private static float SecondLevelModifier = 1.5f;
    private static float ThirdLevelModeifier = 2f;
    private static float FourthLevelModeifier = 3.5f;

    [SerializeField] private float _maxMana;
    [SerializeField] private float _manaRegenSpeed;
    [SerializeField] private ManaView _view;

    private float _statManacost;
    private bool _isCasting = false;
    private float _currentMana;
    private Dictionary<int, float> _modifiersByLevel = new Dictionary<int, float>()
    {
        { 1, 1 },
        { 2, SecondLevelModifier },
        { 3, ThirdLevelModeifier },
        { 4, FourthLevelModeifier }
    };

    public float CurrentMana => _currentMana;

    private void Start()
    {
        _currentMana = _maxMana;
        _view.Init(_maxMana);
    }

    private void FixedUpdate()
    {
        if (_isCasting) return;

        if (_currentMana < _maxMana)
        {
            _currentMana += _manaRegenSpeed;
            _view.UpdateValue(_currentMana);
        }
    }

    public bool TrygetMana(SpellStat spellstat)
    {
        _statManacost = spellstat.ManaCost * _modifiersByLevel[spellstat.CurrentStatLevel + 1];

        return _statManacost <= _currentMana;
    }

    public void SpendMana()
    {
        _currentMana -= _statManacost;
        _view.UpdateValue(_currentMana);

        if (!_isCasting)
            _isCasting = true;
    }

    public void StartRegen() => _isCasting = false;
}
