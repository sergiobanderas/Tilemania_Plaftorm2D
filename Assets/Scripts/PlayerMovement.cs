using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb;

    [SerializeField]
    float runSpeed = 5f;    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();   
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();        
    }

    void Run()
    {
        rb.linearVelocity = new Vector2(moveInput.x * runSpeed, rb.linearVelocity.y);
    }
}
