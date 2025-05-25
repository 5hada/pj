using TMPro;
using UnityEngine;

public class StageTimerUI : MonoBehaviour
{
    public StageTimer stageTimer;
    public TMP_Text timeText;

    void Update()
    {
        float remaining = stageTimer.GetTimeRemaining();
        float total = stageTimer.stageDuration;

        float percent = ((total-remaining) / total) * 100f;
        timeText.text = percent.ToString("F2") + "%";
    }
}
