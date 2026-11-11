using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExhaustionScale : MonoBehaviour
{
    [SerializeField] private WashingFace washingFace;
    private Slider _slider;

    private void Start()
    { 
        StartCoroutine(Exhaustion());
    }
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    IEnumerator Exhaustion()
    {
        while (true)
        {
            if (_slider.value >= 100)
            {
                Debug.Log("Засыпаю");
                GameEvents.OnPlayerDead?.Invoke();
            }
            _slider.value += 1f;
            Debug.Log(_slider.value);
            
            yield return new WaitForSeconds(1f);
        }
    }

    public void ResetExhaustionScale()
    {
        _slider.value = 0;
        Debug.Log("Обнуляем шкалу усталости.");
    }

    private void OnEnable()
    {
        washingFace.OnWashed += ResetExhaustionScale;
    }

    private void OnDisable()
    {
        washingFace.OnWashed -= ResetExhaustionScale;
    }
}
