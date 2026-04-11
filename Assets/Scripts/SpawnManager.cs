using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject guardPrefab;

    public int numberOfGuards = 3;

    public float startZ = 5f;
    public float zSpacing = 5f;

    public float spawnX = 0f;
    public float guardY = 0.5f;

    public float leftBoundary = -5f;
    public float rightBoundary = 5f;

    void Start()
    {
        SpawnGuards();
    }

    void SpawnGuards()
    {
        for (int i = 0; i < numberOfGuards; i++)
        {
            Vector3 spawnPosition = new Vector3(
                spawnX,
                guardY,
                startZ + (i * zSpacing)
            );

            GameObject newGuard = Instantiate(guardPrefab, spawnPosition, Quaternion.identity);

            GuardAI guardScript = newGuard.GetComponent<GuardAI>();

            if (guardScript != null)
            {
                guardScript.leftX = leftBoundary;
                guardScript.rightX = rightBoundary;
            }
        }
    }
}