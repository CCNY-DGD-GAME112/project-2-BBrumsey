using UnityEngine;

public class MusicManager : MonoBehaviour
{  
    /*
    Music Manager:
    Controls the background music for the game.
    Uses a singleton so only one exists and music continues between scenes.
    */

    public static MusicManager instance;

    public AudioClip gameplayMusic;
    public AudioClip victoryMusic;

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayGameplayMusic();
    }

    public void PlayGameplayMusic()
    {
        audioSource.clip = gameplayMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayVictoryMusic()
    {
        audioSource.clip = victoryMusic;
        audioSource.loop = false;
        audioSource.Play();
    }
}