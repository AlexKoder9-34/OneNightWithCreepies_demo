using UnityEngine;
    public class PlayerLook : MonoBehaviour, ILookable
    {
        [SerializeField] private Transform _cameraPivot;
        private float _sensivity = 0.5f;
        private Vector2 _cameraLook;
        private float _cameraRotation;

        public void Look(Vector2 lookDelta)
        {
            _cameraLook =  lookDelta;
        }

        void Update()
        {
            CameraRotate();
        }

        void CameraRotate()
        {
            transform.Rotate(Vector3.up * _cameraLook.x * _sensivity);
            
            _cameraRotation -= _cameraLook.y * _sensivity;
            
            _cameraRotation = Mathf.Clamp(_cameraRotation, -80, 80);
            
            _cameraPivot.localRotation = Quaternion.Euler(_cameraRotation, 0, 0);
        }
    }
