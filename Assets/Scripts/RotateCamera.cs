using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = player.position;
        if (Input.GetKey(KeyCode.Q)){
            // Rotates the camera to the left:
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E)){
            // Rotates the camera to the right
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);


        }
    }
}
