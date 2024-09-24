using UnityEngine;
public class IncreaseEffectDuration : IncreaseStatRequester
{
    [SerializeField] private EffectDurationStat _effectDurationStat;

    private void Awake() => SetStat(_effectDurationStat); 
}
