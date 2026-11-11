using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class JeffMovement : MonoBehaviour
{
    [SerializeField] private GameObject jeffPrefab;
    [SerializeField] private List<Transform> currentWay;
    [SerializeField] private Transform attackPoint;

    public event Action OnAttackPointReached;
    public event Action OnBranchPointReached;
    public event Action OnFusePointReached;
    
    private int _index = 0;
    private int _startIndex = 0;
    
    private int _startPositionAmount = 0;
    private float _jeffMoveDuration = 30f;
    private int _stepValue = 1;
    
    private Coroutine _moveCoroutine;

    public void Start()
    {
        StartMoving();
    }

    private void ResetCurrentWay()
    {
        currentWay = null;
    }

    private void MoveToStartPosition()
    {
        jeffPrefab.transform.SetPositionAndRotation(currentWay[_startIndex].position,currentWay[_startIndex].rotation);
    }

    private void MoveToNextPosition()
    {
        jeffPrefab.transform.SetPositionAndRotation(currentWay[_index].position,currentWay[_index].rotation); 
    }
    
    public void SetRoute(List<Transform> jeffWay)
    {
        ResetCurrentWay();
        
        currentWay  = jeffWay;
        _index = 0;
        
        if (_index >= currentWay.Count)
            return;
        MoveToStartPosition();
    }

    private IEnumerator JeffMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(_jeffMoveDuration);
            MoveForward();
        }
    }

    public void SetStepValue(int newStepValue)
    {
        _stepValue = newStepValue;
    }

    private void ResetStepValue()
    {
        _stepValue = 1;
    }
    
    private void MoveForward()
    {
        _index+= _stepValue;
        
        if (_index > currentWay.Count - 1)
            return;
        
        MoveToNextPosition();
        ResetStepValue();
        
    }
    public void BranchPointReached()
    {
        OnBranchPointReached?.Invoke();
    }
    public void FusePointReached()
    {
        OnFusePointReached?.Invoke();
    }
    public void AttackPointReached()
    {
        StopMoving();
        OnAttackPointReached?.Invoke(); 
    }
    

    public void MoveToAttack()
    {
        jeffPrefab.transform.SetPositionAndRotation(attackPoint.position, attackPoint.rotation);
    }

    private void StopMoving()
    {
        StopCoroutine(_moveCoroutine);
    }

    public void SetToStartPosition()
    {
        _index = _startIndex;
        jeffPrefab.transform.position = currentWay[_startPositionAmount].position;
    }
    
    public void StartMoving()
    {
        _moveCoroutine = StartCoroutine(JeffMove());
    }
}
