using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ManaView : MonoBehaviour
{
    [SerializeField] private Slider _manaSlider;
    //[SerializeField] private Button _fadeButton;

    private float _fadeCount;
    private float _UpdateStep = 0.1f;
    private float _targetValue;

    public void Init(float maxValue)
    {
        _manaSlider.maxValue = maxValue;
        _manaSlider.value = maxValue;
    }

    public void UpdateValue(float newValue)
    {
        _manaSlider.value = newValue;
        //StartCoroutine(UpdateSlider());
    }

    public IEnumerator UpdateSlider()
    {
        while (true)
        {
            _manaSlider.value = Mathf.MoveTowards(_manaSlider.value, _targetValue, _UpdateStep);

            if (_manaSlider.value == _targetValue)
                yield break;
            else
                yield return null;
        }
    }

    public void ShowWarning()
    {
        
    }
}
