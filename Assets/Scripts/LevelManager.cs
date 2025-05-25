using UnityEngine;
using UnityEngine.Rendering;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Selects;

    [SerializeField]
    private Object Player;

    [SerializeField]
    Movement movement;




    private void Awake()
    {

    }
    private void Update()
    {
        EnterScene();
    }


    void EnterScene()
    {
        int selectedLevel;
        if (InputManager.Instance.IsEnterPressed())
        {
            selectedLevel = movement.currentPositionIndex + 1;
            switch (selectedLevel)
            {
                case 1:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Level01");
                    break;
                case 2:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Level02");
                    break;
                case 3:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Level03");
                    break;
                case 4:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Level04");
                    break;
                case 5:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Level05");
                    break;
                case 6:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Level06");
                    break;
                case 7:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Level07");
                    break;
                case 8:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Setting");
                    break;
                case 9:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
                    break;
            }
        }
    }

}
