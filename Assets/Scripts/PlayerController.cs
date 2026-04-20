using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /*
    Player Controller:
    This script controls the player’s movement and jumping.
    It reads keyboard input to move the player
    and plays a sound when the player jumps.
    */

    public float horizontalInput;
    public float verticalInput;
    private float speed = 5f;
    private float moveSpeed = 10f;
    public float jumpForce = 5f;
    public AudioClip jumpSound;
    private AudioSource audioSource;

    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Moving forward, backwards, left and right
        transform.Translate(Vector3.forward * Time.deltaTime * speed * -horizontalInput);
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * verticalInput);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            audioSource.PlayOneShot(jumpSound);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}