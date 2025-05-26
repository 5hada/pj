using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public void EnterTutorial()
    {
        SceneController.Instance.LoadScene("Tutorial");
    }
}
