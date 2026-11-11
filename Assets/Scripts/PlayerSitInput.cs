using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSitInput : MonoBehaviour
{
    private GameplayInputActions _crouchAction;
    private PlayerSit _playerSit;

    private void Awake()
    {
        _crouchAction = new GameplayInputActions();
        _playerSit = GetComponent<PlayerSit>();
    }

    private void ReadCrouch(InputAction.CallbackContext context)
    {
        _playerSit.ChangePlayerState();
    }
    
    private void OnEnable()
    {
        _crouchAction.Gameplay.Crouch.performed += ReadCrouch;
        _crouchAction.Enable();
    }
    private void OnDisable()
    {
        _crouchAction.Gameplay.Crouch.performed -= ReadCrouch;
        _crouchAction.Disable();
    }
}
