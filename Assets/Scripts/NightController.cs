using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NightController : MonoBehaviour
{
    [SerializeField] private int hourValue;
    [SerializeField] private int hourNumber;
    [SerializeField] private int hourLength = 60;
    
    [SerializeField] private List<int> hoursList;
    
    private Coroutine _nightCoroutine;
    
    public static event Action<int> OnHourChanged;

    private void Start()
    {
        _nightCoroutine = StartCoroutine(HourCoroutine());
    }

    IEnumerator HourCoroutine()
    {
        while (Time.timeScale != 0)
        {
            yield return new WaitForSeconds(hourLength);
            ChangeHourAmount();
        }           
    }

    private void StopNightTime()
    {
        StopCoroutine(_nightCoroutine);
    }
    
    private void ChangeHourAmount()
    {
        if (hourNumber >= hoursList.Count)
        {
            GameEvents.OnNightEnd?.Invoke();
            return;
        }
        else if (hourNumber >= hoursList.Count - 1)
        {
            return;
        }
        
        hourNumber++;
        hourValue = hoursList[hourNumber];
        
        OnHourChanged?.Invoke(hourValue);
    }
    
    private void OnEnable()
    {
        GameEvents.OnNightEnd += StopNightTime;
        GameEvents.OnPlayerDead += StopNightTime;
    }

    private void OnDisable()
    {
        GameEvents.OnNightEnd -= StopNightTime;
        GameEvents.OnPlayerDead -= StopNightTime;
    }
}
