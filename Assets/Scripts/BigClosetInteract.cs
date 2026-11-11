using System;
using UnityEngine;
using DG.Tweening;

public class BigClosetInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    
    private Sequence _closetSequence;
    
    private bool _isOpened = false;

    private void Awake()
    {
        ToggleClosetSequence();
    }

    public void Interact(GameObject interactor)
    {
        _isOpened = !_isOpened;
        if (_isOpened == true)
        {
            Open();
        }
        else
        {
            Close();
        }
        
    }

    private void ToggleClosetSequence()
    {
        _closetSequence = DOTween.Sequence();
        
        _closetSequence.Join(leftDoor.transform.DOLocalRotate(new Vector3(0, 0, 0), 1f));
        _closetSequence.Join(rightDoor.transform.DOLocalRotate(new Vector3(0, 0, 0), 1f));

        _closetSequence.Pause();
        _closetSequence.SetAutoKill(false);
    }

    private void Open()
    {
        _closetSequence.PlayForward();
    }

    private void Close()
    {
        _closetSequence.PlayBackwards();
    }

}
