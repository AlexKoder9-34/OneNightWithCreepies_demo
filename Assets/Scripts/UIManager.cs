using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas playerUI;
    [SerializeField] private Canvas securityCameraUI;
    [SerializeField] private GameObject lowedEnergyUI;
    [SerializeField] private Canvas loadingUI;
    
    [SerializeField] private TextMeshProUGUI energyValue;
    [SerializeField] private TextMeshProUGUI hourValue;

    [SerializeField] private Image playerAim;
    
    [SerializeField] private CanvasGroup radioButton;
    
    void Start()
    {
        HideCameraUI();
        HideLoadingUI();
        HideRadioButton();
    }

    public void HideRadioButton()
    {
        radioButton.alpha = 0;
        radioButton.interactable = false;
        radioButton.blocksRaycasts = false;
    }

    public void ShowRadioButton()
    {
        radioButton.alpha = 1;
        radioButton.interactable = true;
        radioButton.blocksRaycasts = true;
    }
    
    private void ChangeHourAmount(int hour)
    {
        hourValue.text = hour.ToString();
    }
    
    private void ChangeEnergyAmount(float energy)
    {
        energyValue.text = energy.ToString() + "%";
    }

    private void ShowLowedEnergyUI()
    {
        lowedEnergyUI.SetActive(true);
    }
    
    public void HideLowedEnergyUI()
    {
        lowedEnergyUI.SetActive(false);
    }
    
    private void ShowPlayerUI()
    {
        playerUI.enabled = true;
    }

    private void ShowCameraUI()
    {
        securityCameraUI.enabled = true;
    }

    private void ShowLoadingUI()
    {
        loadingUI.enabled = true;
    }

    private void ShowPlayerAim()
    {
        playerAim.enabled = true;
    }

    private void HidePlayerUI()
    {
        playerUI.enabled = false;
    }

    private void HideCameraUI()
    {
        securityCameraUI.enabled = false;
    }

    private void HideLoadingUI()
    {
        loadingUI.enabled = false;
    }
    private void HidePlayerAim()
    {
        playerAim.enabled = false;
    }

    IEnumerator OpenMonitorUI()
    {
        ShowLoadingUI();

        yield return new WaitForSeconds(1f);
        
        HideLoadingUI();
        ShowCameraUI();
    }

    private void ShowMonitorUI()
    {
        StartCoroutine(OpenMonitorUI());
    }
    
    private void OnEnable()
    {
        JeffAttackController.OnJeffAttack += HideCameraUI;
        
        NightController.OnHourChanged += ChangeHourAmount;
        
        EnergyController.OnEnergyChanged += ChangeEnergyAmount;
        EnergyController.OnEnergyZeroed += HideCameraUI;
        EnergyController.OnEnergyZeroed += ShowLowedEnergyUI;
        
        Monitor.OnCameraOpen += ShowMonitorUI;
        Monitor.OnCameraOpen += HidePlayerAim;

        Monitor.OnCameraClose += HideCameraUI;
        Monitor.OnCameraClose += ShowPlayerAim;

        Cameras.OnKitchenCameraOpened += ShowRadioButton;
        Cameras.OnKitchenCameraClosed += HideRadioButton;
    }

    private void OnDisable()
    {
        JeffAttackController.OnJeffAttack -= HideCameraUI;
        
        NightController.OnHourChanged -= ChangeHourAmount;
        
        EnergyController.OnEnergyChanged -= ChangeEnergyAmount;
        EnergyController.OnEnergyZeroed -= HideCameraUI;
        EnergyController.OnEnergyZeroed -= ShowLowedEnergyUI;
        
        Monitor.OnCameraOpen -= ShowMonitorUI;
        Monitor.OnCameraOpen -= HidePlayerAim;
        
        Monitor.OnCameraClose -= HideCameraUI;
        Monitor.OnCameraClose -= ShowPlayerAim;
        
        Cameras.OnKitchenCameraOpened -= ShowRadioButton;
        Cameras.OnKitchenCameraClosed -= HideRadioButton;
    }
}
