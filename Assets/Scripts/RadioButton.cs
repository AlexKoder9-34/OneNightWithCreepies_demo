using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RadioButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Button radioButton;
    private AudioClip _radioClip;
    
    public static event Action OnRadioActivated;
    
    private AudioSource _radioSource;

    private void Awake()
    {
        _radioSource = GetComponent<AudioSource>();
        _radioClip = _radioSource.clip;
    }

    private IEnumerator RadioReload()
    {
        radioButton.interactable = false;
        
        OnRadioActivated?.Invoke();
        
        timerText.text = "Use radio";
        
        for (int i = 60; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
            timerText.text = i.ToString();
        }
        
        timerText.text = "Use radio";
        radioButton.interactable = true;
    }

    public void OnRadioButtonClick()
    {
        PlayRadioSound();
        StartCoroutine(RadioReload());
    }

    private void PlayRadioSound()
    {
        _radioSource.PlayOneShot(_radioClip);
    }
    
}
