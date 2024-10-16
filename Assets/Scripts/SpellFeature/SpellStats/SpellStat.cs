using UnityEngine;
using System;

public abstract class SpellStat : MonoBehaviour
{
    [SerializeField] private Sprite _runeImage;
    [SerializeField] private float _manacost;

    private int _maxStatLevel = 3;
    private int _currentStatLevel = 0;

    public float ManaCost => _manacost;

    public event Action LevelIncreased;
    public event Action WasReset;

    public Sprite RuneImage => _runeImage;
    public int CurrentStatLevel => _currentStatLevel;
    public bool IsMaxLevel => _currentStatLevel == _maxStatLevel;
    
    public bool IncreaseLevel()
    {
        if (_currentStatLevel < _maxStatLevel)
        {
            _currentStatLevel++;
            LevelIncreased?.Invoke();
            return true;
        }
            
        return false;
    }

    public void Reset()
    {
        _currentStatLevel = 0;
        WasReset?.Invoke();
    }
}
