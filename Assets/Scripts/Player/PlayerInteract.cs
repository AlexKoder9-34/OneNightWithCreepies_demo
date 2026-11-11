using System;
using UnityEngine;
    public class PlayerInteract : MonoBehaviour
    {
        RaycastHit hit;
        [SerializeField] private float _rayDistance = 10f;
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private LayerMask _layerMask;
        private IInteractable _raycastInteractable;
        private IInteractable _triggerInteractable;

        public void Update()
        {
            Debug.DrawRay(_playerCamera.transform.position, _playerCamera.transform.forward * _rayDistance, Color.red);
        }
        
       public void Interact()
        {
            if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out hit, _rayDistance, _layerMask))
            {
                _raycastInteractable =  hit.collider.GetComponent<IInteractable>();
                
                Debug.Log($"Raycast hit: {hit.collider.name}");
                
                if (_raycastInteractable == null)
                {
                    _raycastInteractable =  hit.collider.GetComponentInParent<IInteractable>();
                }
                if (_raycastInteractable == null)
                {
                    _raycastInteractable =  hit.collider.GetComponentInChildren<IInteractable>();
                }
                if (_raycastInteractable != null)
                {
                    _raycastInteractable.Interact(gameObject);
                }
            }
            else
            {
                if (_triggerInteractable != null)
                {
                    _triggerInteractable.Interact(gameObject);
                }
            }
            
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.isTrigger)
            {
                _triggerInteractable = other.GetComponent<IInteractable>();
                
                if (_triggerInteractable == null)
                {
                    _triggerInteractable =  other.GetComponentInParent<IInteractable>();
                }
                if (_triggerInteractable == null)
                {
                    _triggerInteractable =  other.GetComponentInChildren<IInteractable>();
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
            _triggerInteractable = null;
        }

        
    }
