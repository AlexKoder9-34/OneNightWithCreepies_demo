using System;
using UnityEngine;

public class PlayJeffScreamerSound : MonoBehaviour
{
    [SerializeField] private AudioClip jeffScreamerSound;
    
    private AudioSource _jeffScreamerSource;
    
    private void Awake()
    {
        _jeffScreamerSource = GetComponent<AudioSource>();
    }

    public void PlayJeffScreamerClip()
    {
        _jeffScreamerSource.PlayOneShot(jeffScreamerSound);
    }
    
}
