using System.Collections;
using UnityEngine;

public class GuardAI : Enemy
{
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Patrol());
    }

     IEnumerator Patrol()
    {
        while (true)
        {
            Transform target = waypoints[currentWaypoint];
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.2f)
            {
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                yield return new WaitForSeconds(1);
            }
            yield return null;
        }
    }

    public override void DetectPlayer()
    {
         RaycastHit hit;
        if ((Physics.Raycast(transform.position, transform.forward, out hit, visionRange)))

        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player spotted!");
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }
}
