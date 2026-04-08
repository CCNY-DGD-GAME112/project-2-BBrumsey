using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timeLimit = 20f;
    private float timeRemaining;

    public TextMeshProUGUI timerText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timeRemaining = timeLimit;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            if (timerText != null)
            {
                timerText.text = "Timer: " + Mathf.Ceil(timeRemaining).ToString();
            }
        }
        else
        {
            timeRemaining = 0;

            if (timerText != null)
            {
                timerText.text = "Timer: 0";
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        timerText = FindFirstObjectByType<TextMeshProUGUI>();
    }

    public void CollectTreasure()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("No more scenes in Build Settings.");
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}