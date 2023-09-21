using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool _isPaused = false;
    public bool IsPaused { get { return _isPaused; } }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _isPaused = false;
    }
}
