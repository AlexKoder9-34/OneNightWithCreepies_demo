using System;
using UnityEngine;

    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour, IControllable
    {
        private CharacterController _controller;
        private Vector3 _moveDirection;
        private float _moveSpeed = 30f;
        private void Awake()
        {
            _controller  = GetComponent<CharacterController>();
        }

        void Update()
        {
            MovePlayer();
        }
        
        public void Move(Vector3 direction)
        {
            _moveDirection = direction;
        }

        public void MovePlayer()
        {
           _controller.Move(_moveDirection * Time.deltaTime * _moveSpeed);
        }
    }