using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JeffAttackController : MonoBehaviour
{
    [SerializeField] private Transform jeffScreamerPosition;
    [SerializeField] private GameObject jeff;
    [SerializeField] private Door roomDoor;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerHide playerHide;
    [SerializeField] private SecuritySystemController  securitySystem;

    private Coroutine _attackCoroutine;
    
    public event Action OnJeffAttackFailed;
    public static event Action OnJeffAttack;
    
    public void Attack()
    {
        if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }
        
        _attackCoroutine = StartCoroutine(TryToAttack());
    }

    private void MoveJeffToScreamerPosition()
    {
        jeff.transform.SetPositionAndRotation(jeffScreamerPosition.position, jeffScreamerPosition.rotation);
    }

    private IEnumerator TryToAttack()
    {
        roomDoor.OpenDoor();
        if (playerHide.IsHidden())
        {
            yield return new WaitForSeconds(5f);
            roomDoor.CloseDoor();
            OnJeffAttackFailed?.Invoke();
        }
        else if (securitySystem.IsOpened())
        {
            playerController.RotatePlayerToScreamer();
            OnJeffAttack?.Invoke();
        }
        else
        {
            OnJeffAttack?.Invoke();
        }
    }

    private void OnEnable()
    {
        OnJeffAttack += MoveJeffToScreamerPosition;
    }

    private void OnDisable()
    {
        OnJeffAttack -= MoveJeffToScreamerPosition;
    }
}
