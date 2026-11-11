using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuScene : MonoBehaviour
{
    [SerializeField] CursorController cursorController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadMenu();
    }

    private async Task LoadMenu()
    {
        await Task.Delay(5000);
        cursorController.ShowCursor();
        SceneManager.LoadScene("MenuScene");
    } 
}
