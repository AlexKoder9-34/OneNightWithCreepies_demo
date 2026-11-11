using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    
    private PlayerMoveInput _playerMoveInput;
    private PlayerInteractInput _interactInput;
    private PlayerLookInput _lookInput;
    private PlayerMovement _playerMovement;
    
    private void Awake()
    {
        _lookInput = GetComponent<PlayerLookInput>();
        _playerMoveInput = GetComponent<PlayerMoveInput>();
        _interactInput = GetComponent<PlayerInteractInput>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void LockAllInputs()
    {
        LockInteractInput();
        LockLookInput();
        LockMoveInput();
    }
    
    public void LockInteractInput()
    {
        _interactInput.enabled = false; 
    }

    public void LockPlayerMovement()
    {
        _playerMovement.enabled = false;
    }

    public void UnlockPlayerMovement()
    {
        _playerMovement.enabled = true;
    }
    
    public void LockLookInput()
    {
        _lookInput.enabled = false;
    }

    public void LockMoveInput()
    {
        _playerMoveInput.enabled = false;
    }

    public void LockPlayerCamera()
    {
        playerCamera.enabled = false;
    }

    public void UnlockLookInput()
    {
        _lookInput.enabled = true;
    }

    public void UnlockInteractInput()
    {
        _interactInput.enabled = true; 
    }

    public void UnlockMoveInput()
    {
        _playerMoveInput.enabled = true;
    }

    public void UnlockPlayerCamera()
    {
        playerCamera.enabled = true;
    }

    public void RotatePlayerToScreamer()
    {
        playerCamera.transform.Rotate(0, -90, 0);
    }

    public void OnEnable()
    {
        JeffAttackController.OnJeffAttack += LockAllInputs;
        
        Monitor.OnCameraOpen += LockInteractInput;
        Monitor.OnCameraOpen += LockLookInput;
        Monitor.OnCameraOpen += LockMoveInput;
        Monitor.OnCameraOpen += LockPlayerCamera;
        
        Monitor.OnCameraClose += UnlockInteractInput;
        Monitor.OnCameraClose += UnlockLookInput;
        Monitor.OnCameraClose += UnlockMoveInput;
        Monitor.OnCameraClose += UnlockPlayerCamera;
    }

    public void OnDisable()
    {
        JeffAttackController.OnJeffAttack -= LockAllInputs;
        
        Monitor.OnCameraOpen -= LockInteractInput;
        Monitor.OnCameraOpen -= LockLookInput;
        Monitor.OnCameraOpen -= LockMoveInput;
        Monitor.OnCameraOpen -= LockPlayerCamera;
        
        Monitor.OnCameraClose -= UnlockInteractInput;
        Monitor.OnCameraClose -= UnlockLookInput;
        Monitor.OnCameraClose -= UnlockMoveInput;
        Monitor.OnCameraClose -= UnlockPlayerCamera;
    }
}
