using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] LayerMask groundLayer;           // Select "Ground" in the Inspector
    [SerializeField] float wallCheckDistance = 0.5f;  // How far ahead to look for walls
    [SerializeField] float edgeCheckOffset = 0.4f;    // Horizontal offset of the edge ray
    [SerializeField] float edgeCheckDistance = 1f;    // How far down to look for ground

    Rigidbody2D myRigidbody;
    int direction = 1; // 1 = right, -1 = left

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Physics-related logic goes in FixedUpdate
    void FixedUpdate()
    {
        if (IsTouchingWall() || IsAtEdge())
        {
            TurnAround();
        }

        myRigidbody.linearVelocity = new Vector2(moveSpeed * direction, 0f);
    }

    /// <summary>
    /// Casts a ray forward to detect a wall on the Ground layer.
    /// </summary>
    bool IsTouchingWall()
    {
        Vector2 origin = myRigidbody.position;
        Vector2 rayDirection = Vector2.right * direction;

        Debug.DrawRay(origin, rayDirection * wallCheckDistance, Color.red);
        return Physics2D.Raycast(origin, rayDirection, wallCheckDistance, groundLayer);
    }

    /// <summary>
    /// Casts a ray down, slightly ahead of the enemy, to detect the end of a platform.
    /// </summary>
    bool IsAtEdge()
    {
        Vector2 origin = myRigidbody.position + new Vector2(edgeCheckOffset * direction, 0f);

        Debug.DrawRay(origin, Vector2.down * edgeCheckDistance, Color.yellow);
        // No ground below the front of the enemy means we reached an edge
        return !Physics2D.Raycast(origin, Vector2.down, edgeCheckDistance, groundLayer);
    }

    /// <summary>
    /// Reverses the movement direction and flips the sprite to match.
    /// </summary>
    void TurnAround()
    {
        direction = -direction;
        transform.localScale = new Vector2(direction, 1f);
    }
}
