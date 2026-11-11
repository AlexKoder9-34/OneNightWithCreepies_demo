using System;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] PlayerSitInput playerSitInput;
    [SerializeField] PlayerInteractInput playerInteractInput;
    private void OnTriggerEnter(Collider other)
    {
        PlayerHide playerHide = other.GetComponent<PlayerHide>();

        playerHide.HidePlayer();
        
        playerSitInput.enabled = false;
        playerInteractInput.enabled = false;
    }
    
    private void OnTriggerExit(Collider other)
    {
        PlayerHide playerHide = other.GetComponent<PlayerHide>();

        playerHide.ShowPlayer();
        
        playerSitInput.enabled = true;
        playerInteractInput.enabled = true;
    }
}
