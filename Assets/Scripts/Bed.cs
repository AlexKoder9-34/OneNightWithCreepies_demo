using System;
using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    public void Interact(GameObject interactor)
    {
        PlayerHide playerHide = interactor.GetComponent<PlayerHide>();
        
        if (playerHide == null)
            return;

        if (playerHide.IsHidden())
        {
            playerHide.Show();
        }
        else
        {
            playerHide.Hide();
        }
    }
    
}
