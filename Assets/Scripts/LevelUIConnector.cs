using UnityEngine;
using TMPro;

public class LevelUIConnector : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetTimerText(timerText);
        }
    }
}