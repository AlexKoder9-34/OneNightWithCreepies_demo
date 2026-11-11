using System;
using Unity.VisualScripting;
using UnityEngine;

public class Monitor : MonoBehaviour, IInteractable
{
    [SerializeField] private SecuritySystemController securitySystem;
    public static event Action OnCameraOpen;
    public static event Action OnCameraClose;
    
    public void Interact(GameObject interactor)
    {
        OnCameraOpen?.Invoke();
    }

    public void SwitchOffMonitor()
    {
        OnCameraClose?.Invoke();
    }

    public void KillMonitor()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        JeffAttackController.OnJeffAttack += SwitchOffMonitor;
    }

    private void OnDisable()
    {
        JeffAttackController.OnJeffAttack -= SwitchOffMonitor;
    }
}
