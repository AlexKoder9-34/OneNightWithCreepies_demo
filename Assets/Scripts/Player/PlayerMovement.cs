using System;
using UnityEngine;

    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour, IControllable
    {
        [SerializeField] private float verticalVelocity;
        [SerializeField] private float gravityForce;
        [SerializeField] private float moveSpeed = 30f;
        
        private CharacterController _controller;
        private Vector3 _moveDirection;
        
        
        private void Awake()
        {
            _controller  = GetComponent<CharacterController>();
        }

        void Update()
        {
            DoGravity();
            MovePlayer();
        }
        
        public void Move(Vector3 direction)
        {
            _moveDirection = direction;
        }

        private void MovePlayer()
        {
            Vector3 movement = _moveDirection * moveSpeed;

            movement.y = verticalVelocity;
            
           _controller.Move(movement * Time.deltaTime);
        }
        
        private void DoGravity()
        {
            if (_controller.isGrounded && verticalVelocity < 0)
            {
                verticalVelocity = -5;
            }

            verticalVelocity += gravityForce * Time.deltaTime;
        }
        
    }