using UnityEngine;

public class StageTimer : MonoBehaviour
{
    public float stageDuration = 90f; // �������� ���� �ð� (��)
    private float timer;


    void Start()
    {
        timer = stageDuration;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = 0f;
            EndStage();
        }
    }

    void EndStage()
    {
        SceneController.Instance.LoadScene("GameClear");
    }

    public float GetTimeRemaining()
    {
        return timer;
    }
}
