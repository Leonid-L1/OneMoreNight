using UnityEngine;
public class IncreaseWidth : IncreaseStatRequester
{
    [SerializeField] private WidthStat _widthStat;

    private void Awake() => SetStat(_widthStat);
}
