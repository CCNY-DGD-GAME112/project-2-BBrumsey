using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardAI : Enemy
{
    public Transform[] waypoints;
    private int currentWaypoint = 0;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            StartCoroutine(Patrol());
        }
        else
        {
            Debug.LogWarning("No waypoints assigned to GuardAI.");
        }
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            Transform target = waypoints[currentWaypoint];

            while (Vector3.Distance(transform.position, target.position) > 0.2f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    target.position,
                    speed * Time.deltaTime
                );

                yield return null;
            }

            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            yield return new WaitForSeconds(1f);
        }
    }

    public override void DetectPlayer()
    {
        RaycastHit hit;
        Vector3 rayOrigin = transform.position + Vector3.up * 0.5f;

        if (Physics.Raycast(rayOrigin, transform.forward, out hit, visionRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player spotted!");
            }
        }
    }

    void Update()
    {
        DetectPlayer();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}