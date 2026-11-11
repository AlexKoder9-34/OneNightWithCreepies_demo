using System;
using System.Collections;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    public static event Action<float> OnEnergyChanged;
    public static event Action OnEnergyZeroed;
    
    private float _energyValue = 100f;
    private Coroutine _energyCoroutine;

    private void Update()
    {
        if (_energyValue == 0)
            OnEnergyZeroed?.Invoke(); //покажет UI, который будет видеть игрок на мониторе, вместо системы камер, при отключении электричества.
    }
    
    private void StartEnergyCoroutine()
    {
        if (_energyCoroutine != null)
            return;
        
        _energyCoroutine = StartCoroutine(EnergyDuration());
    }
    
    public void StopEnergyCoroutine()
    {
        if (_energyCoroutine == null)
            return;
        
        StopCoroutine(_energyCoroutine);

        _energyCoroutine = null;
    }

    public void SwitchOffEnergy()
    {
        _energyValue = 0;
    }
    
    IEnumerator EnergyDuration()
    {
        while (true)
        {
            _energyValue--;
            OnEnergyChanged?.Invoke(_energyValue);
            yield return new WaitForSeconds(5f);
        }
    }

    private void OnEnable()
    {
        Monitor.OnCameraOpen += StartEnergyCoroutine;
    }

    private void OnDisable()
    {
        Monitor.OnCameraOpen -= StartEnergyCoroutine;
    }
}
