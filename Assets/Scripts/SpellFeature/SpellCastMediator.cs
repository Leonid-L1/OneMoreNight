using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCastMediator : MonoBehaviour
{
    [SerializeField] private List<IncreaseStatRequester> _increaseRequesters;
    [SerializeField] private ManaHandler _manaHandler;
    [SerializeField] private Button _castButton;
    [SerializeField] private SpellBook _currentSpellBook;
    [SerializeField] private ActiveSpellStatsView _spellView;

    private List<GameObject> _spells = new List<GameObject>();

    private SpellStats _spellStats;

    private void Start()
    {
        CreateSpellStats();
    }

    private void OnEnable()
    {   
        _castButton.onClick.AddListener(CastSpell);

        foreach (IncreaseStatRequester increaseRequester in _increaseRequesters)
            increaseRequester.Requested += CastModifier;
    }

    private void OnDisable()
    {
        _castButton.onClick.RemoveListener(CastSpell);

        foreach (IncreaseStatRequester increaseRequester in _increaseRequesters)
            increaseRequester.Requested -= CastModifier;
    }

    public void CastModifier(SpellStat spellStat)
    {
        if (_manaHandler.TrySpendMana(spellStat))
        {
            spellStat.IncreaseLevel();
            _spellView.Show(spellStat);
        }           
    }

    private void CreateSpellStats()
    {
        _spellStats = new SpellStats();

        foreach (IncreaseStatRequester requester in _increaseRequesters)
            _spellStats.AddStat(requester.SpellStat);
    }

    private void CastSpell()
    {
        _currentSpellBook.Cast(_spellStats);

        foreach (var spell in _spells)
            Destroy(spell);

        _spells.Clear();
        _spellView.Clear();
    }
}
