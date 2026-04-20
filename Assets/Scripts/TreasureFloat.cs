using UnityEngine;

public class TreasureFloat : MonoBehaviour
{

    /*
    Treasure Float:
    This script makes the treasure float up and down
    and slowly rotate to make it stand out.
    */

    public float floatHeight = 0.25f;
    public float floatSpeed = 2;
    public float rotateSpeed = 60;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}