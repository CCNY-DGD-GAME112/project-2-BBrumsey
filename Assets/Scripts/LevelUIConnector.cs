using UnityEngine;
using TMPro;

public class LevelUIConnector : MonoBehaviour
{

    /*
    Level UI Connector:
    This script connects the timer text in the scene
    to the Game Manager so the timer can appear on screen.
    */

    public TextMeshProUGUI timerText;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetTimerText(timerText);
        }
    }
}