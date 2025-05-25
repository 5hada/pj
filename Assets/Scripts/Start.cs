using UnityEngine;

public class Start : MonoBehaviour
{


    void Update()
    {
        if (InputManager.Instance.IsSpacePressed())
        {
            SceneController.Instance.LoadScene("LevelSelect");
        }

        if ( InputManager.Instance.IsExitPressed())
        {
            Application.Quit();
        }
    }
}
