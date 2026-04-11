using UnityEngine;

public class GuardAI : Enemy
{
    public float leftX;
    public float rightX;
    public float waitTime = 1f;

    private bool movingRight = true;
    private float waitCounter = 0f;
    private float lockedY;
    private float lockedZ;

    void Start()
    {
        lockedY = transform.position.y;
        lockedZ = transform.position.z;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (waitCounter > 0)
        {
            waitCounter -= Time.deltaTime;
            return;
        }

        float targetX = movingRight ? rightX : leftX;

        float newX = Mathf.MoveTowards(
            transform.position.x,
            targetX,
            speed * Time.deltaTime
        );

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