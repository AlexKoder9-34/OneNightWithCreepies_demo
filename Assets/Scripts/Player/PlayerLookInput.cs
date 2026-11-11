using UnityEngine;

public class PlayerLookInput : MonoBehaviour
{
    private GameplayInputActions _inputAction;
    private ILookable _lookable;
    private void Awake()
    {
        _lookable = GetComponent<ILookable>();
        _inputAction = new GameplayInputActions();
    }

    private void Update()
    {
        ReadLook();
    }
    
    private void ReadLook()
    {
        var playerLook =  _inputAction.Gameplay.Look.ReadValue<Vector2>();
        _lookable.Look(playerLook);
    }
        
    private void OnEnable()
    {
        _inputAction.Enable();
    }

    private void OnDisable()
    {
        _inputAction.Disable();
    }
}
