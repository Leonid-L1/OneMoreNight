using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.Rendering.Universal;

public class DayToNightTransition : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)] private float _time;

    [SerializeField] private Button _changeToNightCycleButton;
    [SerializeField] private Button _changeToDayCycleButton;
    [SerializeField] private Gradient _gradientNight;
    [SerializeField] private Gradient _gradientDay;
    [SerializeField] private Light2D _lightSource;

    //private float _ChangeDuration = 1.5f;
    //private float _step= 0.1f;
    private float _evaluateValue = 0f;

   // private void Update() => _lightSource.color = _gradientNight.Evaluate(_time);

    private void OnEnable()
    {
        _changeToNightCycleButton.onClick.AddListener(OnNightButtonClick);
        _changeToDayCycleButton.onClick.AddListener(OnDayButtonClick);
    }

    private void OnDisable()
    {
        _changeToNightCycleButton.onClick.RemoveListener(OnNightButtonClick);
        _changeToDayCycleButton.onClick.RemoveListener(OnDayButtonClick);
    }

    private void OnNightButtonClick() => StartCoroutine(ChangeLightToNight());

    private void OnDayButtonClick() => StartCoroutine(ChangeLightToDay());


    public IEnumerator ChangeLightToNight()
    {   
        while (true)
        {
            if (_evaluateValue >= 1f)
            {
                _evaluateValue = 0f;
                yield break;
            }               

            _evaluateValue += Time.deltaTime;
            Debug.Log("Couroutine");
            _lightSource.color = _gradientNight.Evaluate(_evaluateValue);
            yield return null;
        }      
    }
    public IEnumerator ChangeLightToDay()
    {
        while (true)
        {
            if (_evaluateValue >= 1f)
            {
                _evaluateValue = 0f;
                yield break;
            }

            _evaluateValue += Time.deltaTime;
            Debug.Log("Couroutine");
            _lightSource.color = _gradientDay.Evaluate(_evaluateValue);
            yield return null;
        }
    }
}
