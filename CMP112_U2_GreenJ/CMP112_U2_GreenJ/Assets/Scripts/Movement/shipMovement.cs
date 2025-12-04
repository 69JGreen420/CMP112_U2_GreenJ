using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class shipMovement : MonoBehaviour
{

    private bool isGrounded = false;
    private bool jumpRequested = false;
    private bool jumpSoundRequested = false;
    private Rigidbody2D rb;

    //Set direction to always be going right
    private float direction = 1;

    public float speed;
    public float jumpForce;

    //Speed changers
    public float speedIncrease;
    public float speedDecrease;

    //Include GameManager to connect UI
    public GameManager GameManager;

    AudioSource jumpSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>(); //Connect jumpSound audio to Ship

    }

    public void setJumpSoundRequested(bool soundRequested)
    {

        jumpSoundRequested = soundRequested;

    }

    void Update()
    {
        
        jumpRequested = Keyboard.current.wKey.isPressed;

        //Ensure jumpSound only plays once
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {

            jumpSound.Play(); //When the Ship jumps, play jumpSound
            jumpSoundRequested = true;

        }

        if (!Keyboard.current.wKey.isPressed)
        {

            jumpSoundRequested = false;

        }

    }

    //Update is called once per frame
    void FixedUpdate()
    {

        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        if (jumpRequested)
        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        }


    }

    //isGrounded setter
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

        //Speed changers (speed set in gameObject)

        if (collision.gameObject.CompareTag("speedBoost"))
        {

            //Increase speed specified amount upon collision with speedIncrease isTrigger GameObject
            speed += speedIncrease;

        }

        if (collision.gameObject.CompareTag("speedDecrease"))
        {

            //Decrease speed specified amount upon collision with speedIncrease isTrigger GameObject
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