using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractInput : MonoBehaviour
{
    private PlayerInteract _playerInteract;
    private GameplayInputActions _interactAction;
    void Awake()
    {
        _playerInteract = GetComponent<PlayerInteract>();
        _interactAction = new GameplayInputActions();
    }
    
    void Update()
    {
        ReadInteract();
    }

    public void ReadInteract()
    {
        if (_interactAction.Gameplay.Interact.WasPressedThisFrame())
        {
            _playerInteract.Interact();
        }
    }
    
    void OnEnable()
    {
        _interactAction.Enable();
    }

    void OnDisable()
    {
        _interactAction.Disable();
    }
}
