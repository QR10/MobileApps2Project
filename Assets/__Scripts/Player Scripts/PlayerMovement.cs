using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] private AudioClip jumpClip;

    // To assign which layers should be hit with the Raycast 
    [SerializeField] private LayerMask groundLayerMask;

    void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = transform.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // If W key is pressed and the player is in the ground
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            // Play jump animation
            anim.Play("Jump");

            // play jump audio
            AudioSource.PlayClipAtPoint(jumpClip, transform.position);

            // Set the velocity of the jump
            float jumpVelocity = 10f;

            // Calculate the rigidbody velocity 
            rb.velocity = Vector2.up * jumpVelocity;
        }

        MovePlayer();

    }

    // Check if the player is in the ground
    private bool  IsGrounded()
    {
        // Use boxcollider center and size with no rotation on the angle (0f) and the direction down to move a tiny bit (.1f) 
        // Which will return a Raycast hit
        RaycastHit2D raycastHit2d =  Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);
        
        // If the Raycast collider is not null, means that we hit the ground therefore return true
        return raycastHit2d.collider != null;
    }

    private void MovePlayer()
    {
        // If A pressed apply negative velocity to the rigid body to move to the left
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }
        else
        {
            // If D pressed apply velocity to the rigid body to move to the right
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            }
            else
            {
                // No keys pressed
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }
}
