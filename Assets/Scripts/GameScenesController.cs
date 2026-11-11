using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesController : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("NightScene");
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    private void LoadNightOverScene()
    {
        SceneManager.LoadScene("NightEndScene");
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerDead += LoadGameOverScene;
        GameEvents.OnNightEnd += LoadNightOverScene;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerDead -= LoadGameOverScene;
        GameEvents.OnNightEnd -= LoadNightOverScene;
    }
}
