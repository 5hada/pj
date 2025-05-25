using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    private bool isPaused = false;

    private void Start()
    {
        pausePanel.SetActive(false);
        Cursor.visible = false;
    }

    private void Update()
    {
        if (InputManager.Instance.IsExitPressed())
        {
            if (GameOverManager.isGameOver) return;

            if (!isPaused) Pause();
            else Resume();
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
        pausePanel.SetActive(false);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // ¶Ç´Â Application.Quit();
    }
}
