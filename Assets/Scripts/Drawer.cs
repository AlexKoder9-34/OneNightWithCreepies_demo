using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Drawer : MonoBehaviour, IInteractable
{
    private Animator _animator;
    private bool _isOpen;

    private void Awake()
    {
        _animator =  GetComponent<Animator>();
    }

    public void Interact(GameObject interactor)
    {
        Debug.Log("Interacting with " + interactor);
        
        _isOpen = !_isOpen;
        if (_isOpen == true)
            OpenDrawer();
        else
            CloseDrawer();
    }

    public void OpenDrawer()
    {
        _animator.speed = 1f;
        _animator.Play("DrawerOpen");
    }

    public void CloseDrawer()
    {
        _animator.speed = 1f;
        _animator.Play("DrawerClose");
    }
}
