using UnityEngine;
public class IncreaseForce : IncreaseStatRequester
{
    [SerializeField] private ForceStat _forceStat;
    private void Awake() => SetStat(_forceStat);
}
