using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip doorSound;
    
    private Animator _animator;
    private AudioSource _doorAudio;
    
    private bool _isOpen = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _doorAudio = GetComponent<AudioSource>();
    }

    public void Interact(GameObject interactor)
    {
        if (_isOpen == false)
            OpenDoor();
        else
            CloseDoor();
    }

    public void OpenDoor()
    {
        _isOpen = !_isOpen;
        _animator.Play("DoorOpen");
        PlayDoorAudio();
    }
    
    public void CloseDoor()
    {
        _isOpen = !_isOpen;
        _animator.Play("DoorClose");
        PlayDoorAudio();
    }

    private void PlayDoorAudio()
    {
        _doorAudio.PlayOneShot(doorSound);
    }
}
    
