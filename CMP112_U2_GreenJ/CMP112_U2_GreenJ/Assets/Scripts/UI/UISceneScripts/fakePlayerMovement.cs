using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class fakePlayerMovement : MonoBehaviour
{
    private bool isGrounded = false;
    private bool jumpRequested = false;
    private bool insideJumper = false;
    private int jumpCount;
    private Rigidbody2D rb;

    //Set direction to always be going right
    private float direction = 1;

    public float speed;
    public float jumpForce;

    AudioSource jumpSound;
    AudioSource coinSound;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        //AudioSource stored as an array to allow multiple sound entries
        AudioSource[] sounds = GetComponents<AudioSource>();
        jumpSound = sounds[0]; //Connect jumpSound audio to Player

        // Set isGrounded initially to true upon start
        isGrounded = true;

    }

    void Update()
    {

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {

            //Set jumpRequested to true when W key is pressed
            jumpRequested = true;

            //Jumper logic defined in Update() so jump can happen any frame inside GameObject
            if (insideJumper && jumpCount == 0)
            {

                rb.AddForce(Vector2.up * (jumpForce + 5), ForceMode2D.Impulse);
                jumpSound.Play();

                jumpCount = 1; //Set jumpCount to 1
                jumpRequested = false; //Disallow jump after pressed

            }

        }

    }

    //Update is called once per frame
    void FixedUpdate()
    {

        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        if (jumpRequested && isGrounded)
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpSound.Play(); //When the Player jumps, play jumpSound
            jumpRequested = false; //Reset jumpRequested so Player can't infinitely jump

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

            // If touching the Ground layer, set isGrounded to true
            isGrounded = true;
            Debug.Log("Grounded is true");

            jumpCount = 0;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Coin"))
        {

            coinSound.Play();
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Jumper"))
        {

            // Set insideJumper to true when active. This is linked to code in Update()
            insideJumper = true;

        }

        if (collision.gameObject.CompareTag("Bouncer") && isGrounded)
        {

            // When the Player interacts with this, they will launch up
            rb.AddForce(Vector2.up * (jumpForce + 8), ForceMode2D.Impulse);

        }

        if (collision.gameObject.CompareTag("Wall"))
        {

            direction *= -1;

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

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Jumper"))
        {

            // After Player has left Jumper, reset everything
            insideJumper = false;
            jumpCount = 0;

        }

    }

}