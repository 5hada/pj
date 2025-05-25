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
                    SceneController.Instance.LoadScene("Level01");
                    break;
                case 2:
                    SceneController.Instance.LoadScene("Level02");
                    break;
                case 3:
                    SceneController.Instance.LoadScene("Level03");
                    break;
                case 4:
                    SceneController.Instance.LoadScene("Level04");
                    break;
                case 5:
                    SceneController.Instance.LoadScene("Level05");
                    break;
                case 6:
                    SceneController.Instance.LoadScene("Level06");
                    break;
                case 7:
                    SceneController.Instance.LoadScene("Level07");
                    break;
                case 8:
                    SceneController.Instance.LoadScene("Setting");
                    break;
                case 9:
                    SceneController.Instance.LoadScene("Main");
                    break;
            }
        }
    }

}
