using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    /*
    Game Manager:
    This script controls the game timer and level progression.
    It keeps track of the player’s time, loads the next level,
    and saves the best time when the player wins.
    */

    public static GameManager Instance;

    public float elapsedTime = 0f;
    public TextMeshProUGUI timerText;

    private bool isRunning = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    public void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = "Timer: " + minutes + ":" + seconds.ToString("00");
        }
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        return minutes + ":" + seconds.ToString("00");
    }

    public void SetTimerText(TextMeshProUGUI newTimerText)
    {
        timerText = newTimerText;
        UpdateTimerDisplay();
    }

    public void LoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        isRunning = false;

        GameData.finalTime = elapsedTime;

        float savedBestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);

        if (elapsedTime < savedBestTime)
        {
            savedBestTime = elapsedTime;
            PlayerPrefs.SetFloat("BestTime", savedBestTime);
            PlayerPrefs.Save();
        }

        GameData.bestTime = savedBestTime;

        SceneManager.LoadScene("Win Scene");
    }

    public void ResetRun()
    {
        elapsedTime = 0f;
        isRunning = true;
    }
}