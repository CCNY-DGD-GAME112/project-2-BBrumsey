using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinSceneManager : MonoBehaviour
{

    /*
    Win Scene Manager:
    This script shows the player’s final time
    and best time on the win screen.
    It also controls the replay and title buttons.
    */

    public TextMeshProUGUI finalTimeText;
    public TextMeshProUGUI bestTimeText;

    void Start()
    {
        int finalMinutes = Mathf.FloorToInt(GameData.finalTime / 60);
        int finalSeconds = Mathf.FloorToInt(GameData.finalTime % 60);
        finalTimeText.text = "Final Time: " + finalMinutes + ":" + finalSeconds.ToString("00");
        MusicManager.instance.PlayVictoryMusic();

        if (GameData.bestTime == Mathf.Infinity)
        {
            bestTimeText.text = "Best Time: --:--";
        }
        else
        {
            int bestMinutes = Mathf.FloorToInt(GameData.bestTime / 60);
            int bestSeconds = Mathf.FloorToInt(GameData.bestTime % 60);
            bestTimeText.text = "Best Time: " + bestMinutes + ":" + bestSeconds.ToString("00");
        }
    }

    public void PlayAgain()
    {
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }

        SceneManager.LoadScene("Level 1");
    }

    public void BackToTitle()
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.PlayGameplayMusic();
        }

        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }

        SceneManager.LoadScene("Title Scene");
    }
}