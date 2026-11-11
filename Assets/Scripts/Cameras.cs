using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cameras : MonoBehaviour
    {
        [SerializeField] private Camera currentSecurityCamera;
        [SerializeField] private List<Transform> cameraList;

        public static event Action OnKitchenCameraOpened;
        public static event Action OnKitchenCameraClosed;

        private const int KitchenCameraIndex = 4;
        
        private void Start()
        {
            UseCamera(1);
            OnKitchenCameraClosed?.Invoke();
        }

        public void UseCamera(int index)
        {
            currentSecurityCamera.transform.SetPositionAndRotation(cameraList[index].position, cameraList[index].rotation);
            switch (index)
            {
                case KitchenCameraIndex:
                    OnKitchenCameraOpened?.Invoke();
                        break;
                default:
                    OnKitchenCameraClosed?.Invoke();
                    break;
            };
        }
    }
