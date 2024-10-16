using System;
using UnityEngine;
using UnityEngine.UI;


public abstract class IncreaseStatRequester : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Color _disabledColor;
    [SerializeField] private Color _normalColor;

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

    public void Lock()
    {
        Debug.Log("Locked");
        _button.enabled = false;
        _buttonImage.color = _disabledColor;
    }

    private void RequestIncrease() => Requested?.Invoke(_spellStat);

    private void OnStatLevelIncreased()
    {
        if (_spellStat.IsMaxLevel)
            Lock();
    }

    private void OnStatReset()
    {
        Debug.Log(this.GetType() + " Reset");
        _buttonImage.color = _normalColor;
        _button.enabled = true;
    }
}
