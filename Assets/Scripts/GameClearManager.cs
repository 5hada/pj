using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearManager : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("LevelSelect");
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
