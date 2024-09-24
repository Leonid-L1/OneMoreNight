using UnityEngine;
public class IncreaseLength : IncreaseStatRequester
{
    [SerializeField] private LengthStat _lengthStat;

    private void Awake() => SetStat(_lengthStat);
}
