using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10;
    [SerializeField] private float playerJumpForce = 2;

    public bool isPlayerGrounded;
    
    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, playerJumpForce);
        }
    }
    private void FixedUpdate()
    {
        isPlayerGrounded = Physics.Raycast(
            transform.position, 
            Vector2.down,
            out RaycastHit hit,
            5f);

        if (hit.collider != null && hit.collider.CompareTag("Ground"))
        {
            isPlayerGrounded = true;
        }
        else
        {
            isPlayerGrounded = false;
        }
        
        float horizontalInput = Input.GetAxis("Horizontal");
        
        rb.linearVelocity = new Vector2(horizontalInput * playerSpeed, rb.linearVelocity.y);
    }
}
