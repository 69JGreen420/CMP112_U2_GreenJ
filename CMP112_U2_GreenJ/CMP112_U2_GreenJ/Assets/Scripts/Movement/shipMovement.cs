using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class shipMovement : MonoBehaviour
{

    private bool isGrounded = false;
    private bool jumpRequested = false;
    private Rigidbody2D rb;
    private float direction = 1;
    public float speedIncrease;
    public float speedDecrease;
    public float speed;
    public float jumpForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        
        jumpRequested = Keyboard.current.wKey.isPressed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        if (jumpRequested)
        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        }


    }

    public void setIsGrounded(bool ground)
    {

        isGrounded = ground;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collision");
        if (collision.gameObject.layer == 8)
        {

            isGrounded = false;
            Debug.Log("Grounded is false");

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("speedBoost"))
        {

            speed += speedIncrease;

        }

        if (collision.gameObject.CompareTag("speedDecrease"))
        {

            speed -= speedDecrease;

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {

        Debug.Log("Collision");
        if (collision.gameObject.layer == 8)
        {

            isGrounded = false;
            Debug.Log("Grounded is false");

        }

    }

}