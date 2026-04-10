using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardAI : Enemy
{
    public Transform[] waypoints;
    private int currentWaypoint = 0;

    private float lockedY;
    private float lockedZ;

    void Start()
    {
        lockedY = transform.position.y;
        lockedZ = transform.position.z;

        if (waypoints.Length >= 2)
        {
            StartCoroutine(Patrol());
        }
        else
        {
            Debug.LogWarning("GuardAI needs 2 waypoints assigned.");
        }
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            Transform target = waypoints[currentWaypoint];

            while (Mathf.Abs(transform.position.x - target.position.x) > 0.05f)
            {
                float newX = Mathf.MoveTowards(
                    transform.position.x,
                    target.position.x,
                    speed * Time.deltaTime
                );

                transform.position = new Vector3(newX, lockedY, lockedZ);

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
            PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();

            if (playerRespawn != null)
            {
                playerRespawn.Respawn();
            }
        }
    }
}