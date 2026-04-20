using UnityEngine;

public class GuardAI : Enemy
{

    /*
Guard AI:
This script makes the guard move back and forth
between two points. If the player touches the guard,
the player is sent back to the respawn point.
*/
    public float leftX;
    public float rightX;
    public float waitTime = 0.5f;

    private bool movingRight = true;
    private float waitCounter = 0;
    private float lockedY;
    private float lockedZ;

    void Start()
    {
        lockedY = transform.position.y;
        lockedZ = transform.position.z;
    }

    void Update()
    {
        if (waitCounter > 0)
        {
            waitCounter -= Time.deltaTime;
            return;
        }

        float targetX = movingRight ? rightX : leftX;

        float newX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        transform.position = new Vector3(newX, lockedY, lockedZ);

        if (Mathf.Abs(transform.position.x - targetX) < 0.05f)
        {
            movingRight = !movingRight;
            waitCounter = waitTime;
        }
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