using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float jumpForce = 5f;
    
    private Rigidbody rb;
    private float moveX, moveY;
    private bool isGrounded = true;
    private bool jumpRequested = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        Mover();

        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            jumpRequested = false;
        }
    }

    void Mover()
    {
        Vector3 moveDir = transform.right * moveX + transform.forward * moveY;
        Vector3 vel = moveDir.normalized * speed;
        
        rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Chao")) isGrounded = true;
    }
}