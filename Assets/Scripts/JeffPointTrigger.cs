using System;
using UnityEngine;

public enum SpecialPoint
{
    Attack,
    Branch,
    Fuse
}

public class JeffPointTrigger : MonoBehaviour
{
    [SerializeField] private SpecialPoint specialPoint;

    private void OnTriggerEnter(Collider other)
    {
        JeffMovement jeffMovement = other.GetComponentInChildren<JeffMovement>();
        
        Debug.Log(jeffMovement);
        
        if(jeffMovement == null) return;

        switch (specialPoint)
        {
            case SpecialPoint.Attack:
                Debug.Log("Я атакую");
                jeffMovement.AttackPointReached();
                break;
            case SpecialPoint.Branch:
                Debug.Log("Кручу верчу, обмануть тебя хочу");
                jeffMovement.BranchPointReached();
                break;
            case SpecialPoint.Fuse:
                Debug.Log("Выключаю свет");
                jeffMovement.FusePointReached();
                break;
        }
    }
}
