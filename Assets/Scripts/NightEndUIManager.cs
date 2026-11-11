using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightEndUIManager : MonoBehaviour
{
    [SerializeField] private GameObject endTextPanel;
    [SerializeField] private TextMeshProUGUI winHourValue;
    [SerializeField] private TextMeshProUGUI winHourText;
    [SerializeField] private CursorController cursorController;
    
    void Start()
    {
        StartCoroutine(StartNightTextAnimation());
    }

    private IEnumerator StartNightTextAnimation()
    {
        yield return new WaitForSeconds(1f);
        
        winHourValue.text = "2:00";
        
        yield return new WaitForSeconds(1f);
        
        winHourValue.text = "6:00";
        
        yield return new WaitForSeconds(1f);
        
        winHourText.text = "PM";
        
        yield return new WaitForSeconds(5f);
        
        endTextPanel.SetActive(true);
        
        yield return new WaitForSeconds(10f);
        
        cursorController.ShowCursor();
        SceneManager.LoadScene("MenuScene");
        
    }
}
