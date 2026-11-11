using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveInput : MonoBehaviour
    {
        private IControllable _controllable;
        private GameplayInputActions _inputAction;
        private void Awake()
        {
            _inputAction = new GameplayInputActions();
            _controllable = GetComponent<IControllable>();
        }

        private void Update()
        {
            ReadMove();
        }

        private void ReadMove()
        {
            var playerInput = _inputAction.Gameplay.Move.ReadValue<Vector2>();
            Debug.Log("Move input: " + playerInput);
            Vector3 direction = transform.right * playerInput.x + transform.forward * playerInput.y;
            direction.y = 0;
            direction.Normalize();
            _controllable.Move(direction);
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
