using UnityEngine;

public class CursorController : MonoBehaviour
{
    private void Awake()
    {
        HideCursor();
    }
    private void HideCursor()
    {
        Cursor.visible = false;
    }
    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    private void OnEnable()
    {
        Monitor.OnCameraOpen += ShowCursor;
        Monitor.OnCameraClose += HideCursor;
    }
    private void OnDisable()
    {
        Monitor.OnCameraOpen -= ShowCursor;
        Monitor.OnCameraClose -= HideCursor;
    }
}
