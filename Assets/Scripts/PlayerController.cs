using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float mouseSpeed = 150f;
    public float jumpForce = 8f;
    bool isGrounded = false;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        Jump();
    }

    void OnCollisionEnter(Collision other)
    {
        GroundCheck(other);
    }

    void MovePlayer()
    {
        float speedX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float speedZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;

        transform.Translate(speedX, 0.0f, speedZ);
        transform.Rotate(0.0f, mouseX, 0.0f);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void GroundCheck(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
