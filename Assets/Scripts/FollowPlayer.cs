using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 100f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            offset = Quaternion.AngleAxis(-rotationSpeed * Time.deltaTime, Vector3.up) * offset;
        }

        if (Input.GetKey(KeyCode.E))
        {
            offset = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up) * offset;
        }

        transform.position = player.position + offset;
        transform.LookAt(player);
    }
}