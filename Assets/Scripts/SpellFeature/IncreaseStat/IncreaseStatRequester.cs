using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class IncreaseStatRequester : MonoBehaviour
{
    [SerializeField] private Button _button;

    private SpellStat _spellStat;

    public event Action<SpellStat> Requested;
    public SpellStat SpellStat => _spellStat;

    protected void SetStat(SpellStat spellStat) => _spellStat = spellStat;

    private void Awake() => _button = GetComponent<Button>();
    
    private void OnEnable()
    {   
        _button.onClick.AddListener(RequestIncrease);
        _spellStat.LevelIncreased += OnStatLevelIncreased;
        _spellStat.WasReset += OnStatReset;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(RequestIncrease);
        _spellStat.LevelIncreased -= OnStatLevelIncreased;
        _spellStat.WasReset -= OnStatReset;
    }

    private void RequestIncrease() => Requested?.Invoke(_spellStat);

    private void OnStatLevelIncreased()
    {
        if (_spellStat.IsMaxLevel)
            _button.enabled = false;
    }

    private void OnStatReset() => _button.enabled = true;
}
