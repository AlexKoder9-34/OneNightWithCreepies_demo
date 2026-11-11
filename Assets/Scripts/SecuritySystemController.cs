using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuritySystemController : MonoBehaviour
{
    [SerializeField] private Camera securityCamera;
    [SerializeField] private PlayerController playerController;

    private bool _isOpened;
    
    public bool IsOpened() => _isOpened; 
    
    private void SwitchOnCamera()
    {
        _isOpened = true;
        securityCamera.enabled = true;
    }

    private void SwitchOffCamera()
    {
        _isOpened = false;
        securityCamera.enabled = false;
    }

    private void OnEnable()
    {
        Monitor.OnCameraOpen += SwitchOnCamera;
        Monitor.OnCameraClose += SwitchOffCamera;
        
        EnergyController.OnEnergyZeroed += SwitchOffCamera;
    }

    private void OnDisable()
    {
        Monitor.OnCameraOpen -= SwitchOnCamera;
        Monitor.OnCameraClose -= SwitchOffCamera;
        
        EnergyController.OnEnergyZeroed -= SwitchOffCamera;
    }
    
}
