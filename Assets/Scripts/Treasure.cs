using UnityEngine;

public class Treasure : MonoBehaviour
{

    /*
    Treasure:
    This script checks if the player touches the treasure.
    When collected, it loads the next level.
    */

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.LoadNextLevel();
            Destroy(gameObject);
        }
    }
}