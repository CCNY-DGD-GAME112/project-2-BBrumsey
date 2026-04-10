using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float elapsedTime = 0f;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI bestTimeText;
    public GameObject restartButton;

    private bool isRunning = true;
    private bool hasWon = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }

        if (restartButton != null)
        {
            restartButton.SetActive(false);
        }

        UpdateTimerDisplay();
        UpdateBestTimeDisplay();
    }

    void Update()
    {
        if (isRunning && !hasWon)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Timer: " + GetFormattedTime();
        }
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        return minutes + ":" + seconds.ToString("00");
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void WinGame()
    {
        hasWon = true;
        StopTimer();

        string finalTime = GetFormattedTime();

        if (winText != null)
        {
            winText.gameObject.SetActive(true);
            winText.text = "YOU WIN!\nFinal Time: " + finalTime;
        }

        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }

        float bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);

        if (elapsedTime < bestTime)
        {
            PlayerPrefs.SetFloat("BestTime", elapsedTime);
            PlayerPrefs.Save();
        }

        UpdateBestTimeDisplay();
    }

    void UpdateBestTimeDisplay()
    {
        if (bestTimeText != null)
        {
            float bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);

            if (bestTime == Mathf.Infinity)
            {
                bestTimeText.text = "Best Time: --:--";
            }
            else
            {
                int minutes = Mathf.FloorToInt(bestTime / 60);
                int seconds = Mathf.FloorToInt(bestTime % 60);

                bestTimeText.text = "Best Time: " + minutes + ":" + seconds.ToString("00");
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}