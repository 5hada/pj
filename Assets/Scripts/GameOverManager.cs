using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static bool isGameOver = false;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject idleProgressText;

    private void Start()
    {
        isGameOver = false;
        gameOverPanel.SetActive(false);
        idleProgressText.SetActive(true);
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        isGameOver = true;
        gameOverPanel.SetActive(true);
        idleProgressText.SetActive(false);
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.visible = false;

    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // ¶Ç´Â Application.Quit();
        Cursor.visible = false;
    }
}
