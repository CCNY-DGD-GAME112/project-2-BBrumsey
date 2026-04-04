using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    private float speed = 5;
    private float turnSpeed = 10;
    public float jumpForce = 5f;
    private bool isGrounded;
    private Rigidbody rb;

   
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Makes it so the player moves forward or backward:
        transform.Translate(Vector3.forward * Time.deltaTime * speed * -horizontalInput);
        // Makes it so the player moves to the left or right:
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * verticalInput);
        
        // Makes it so the character will jump

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;

    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;       
    }
}
