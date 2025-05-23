using UnityEngine;
using UnityEngine.Rendering;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Selects;

    [SerializeField]
    private Object Player;

    PlayerPosition playerPosition;



    private void Awake()
    {

    }

    
    void EnterScene()
    {
        if(InputManager.Instance.IsEnterPressed())
        {
            int selectedLevel = playerPosition.currentPosition;
            LoadLevel(selectedLevel);
        }
    }
    void select_check()
    {

    }


}
