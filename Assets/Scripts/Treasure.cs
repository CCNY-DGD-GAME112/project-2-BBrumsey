using UnityEngine;

public class Treasure : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.WinGame();
            Destroy(gameObject);
        }
    }
}