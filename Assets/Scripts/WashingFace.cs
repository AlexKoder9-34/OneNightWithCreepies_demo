using System;
using UnityEngine;

public class WashingFace : MonoBehaviour, IInteractable
{
    [SerializeField] AudioSource washingAudioSource;
    [SerializeField] AudioClip washingSound;
    public event Action OnWashed;
    public void Interact(GameObject interactor)
    {
        washingAudioSource.PlayOneShot(washingSound);
        OnWashed?.Invoke();
    }
}
