using UnityEngine;

public class TreasureSound : MonoBehaviour
{
    public Transform player;
    public float maxDistance = 10;
    public float minDistance = 2;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= maxDistance)
        {
            float volume = 1 - (distance / maxDistance);
            audioSource.volume = Mathf.Clamp(volume, 0, 1);

            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}