using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class JeffAI : MonoBehaviour
{
    [SerializeField] private EnergyController energyController;

    [SerializeField] private JeffRoutes jeffRoutes;
    [SerializeField] private JeffMovement jeffMovement;
    [SerializeField] private JeffAttackController jeffAttackController;

    private Coroutine _fuseCoroutine;
    void Awake()
    {
        ChooseWay();
    }

    private void ChooseWay()
    {
        int chosenWay = Random.Range(1, 3);

        switch (chosenWay)
        {
            case 1:
                jeffMovement.SetRoute(jeffRoutes.Way1());
                break;
            case 2:
                jeffMovement.SetRoute(jeffRoutes.Way2());
                break;
        }
    }

    private void ChooseNextPoint()
    {
        int chosenPoint = Random.Range(1, 3);
        jeffMovement.SetStepValue(chosenPoint);
    }

    private IEnumerator StartAttackCoroutine()
    {
        yield return new WaitForSeconds(15f);
        jeffAttackController.Attack();
    }

    private IEnumerator FuseBreakCoroutine()
    {
        yield return new WaitForSeconds(10f);
        
        
        energyController.SwitchOffEnergy();
        jeffMovement.MoveToAttack();
        
        _fuseCoroutine = null;
    }
    
    private void JeffAttackPointReached()
    {
        StartCoroutine(StartAttackCoroutine());
    }

    private void RetryAfterJeffAttack()
    {
        if (Random.value > 0.9f)
        {
            jeffMovement.StartMoving();
            //Так Джефф продолжит идти по точкам, в сторону кухни
        }
        else
        {
            //А вот так Джефф вернётся на исходную и заново пойдёт к игроку
            jeffMovement.SetToStartPosition();
            ChooseWay();
            jeffMovement.StartMoving();
        }
    }

    private void JeffBreakFuseBox()
    {
        if (_fuseCoroutine == null)
        {
            _fuseCoroutine = StartCoroutine(FuseBreakCoroutine());
        }
    }

    private void JeffHeardRadio()
    {
        if (_fuseCoroutine != null)
        {
            StopCoroutine(_fuseCoroutine);
            _fuseCoroutine = null;
        }
        
        jeffMovement.MoveToAttack();
    }

    private void OnEnable()
    {
        RadioButton.OnRadioActivated += JeffHeardRadio;
        
        jeffAttackController.OnJeffAttackFailed += RetryAfterJeffAttack;
        jeffMovement.OnAttackPointReached += JeffAttackPointReached;
        jeffMovement.OnBranchPointReached += ChooseNextPoint;
        jeffMovement.OnFusePointReached += JeffBreakFuseBox;
    }

    private void OnDisable()
    {
        RadioButton.OnRadioActivated -= JeffHeardRadio;
        
        jeffAttackController.OnJeffAttackFailed -= RetryAfterJeffAttack;
        jeffMovement.OnAttackPointReached -= JeffAttackPointReached;
        jeffMovement.OnBranchPointReached -= ChooseNextPoint;
        jeffMovement.OnFusePointReached -= JeffBreakFuseBox;
    }
}
