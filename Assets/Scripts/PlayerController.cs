using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    private float speed = 5;
    private float turnSpeed = 10;
   
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Makes it so the player moves forward or backward:
        transform.Translate(Vector3.forward * Time.deltaTime * speed * -horizontalInput);
        // Makes it so the player moves to the left or right:
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * verticalInput);
    }
   
   
}
