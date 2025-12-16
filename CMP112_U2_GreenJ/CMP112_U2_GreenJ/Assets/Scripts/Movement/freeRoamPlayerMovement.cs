using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class freeRoamPlayerMovement : MonoBehaviour
{
    private bool isGrounded = false;
    private bool jumpRequested = false;
    private bool insideJumper = false;
    private int jumpCount;
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    //Speed changers
    public float speedIncrease;
    public float speedDecrease;

    //Call deathSoundPlayer to interact with script
    public GameObject deathSoundPlayer;

    //Include GameManager to connect UI
    public GameManager GameManager;

    AudioSource jumpSound;
    AudioSource coinSound;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        //AudioSource stored as an array to allow multiple sound entries
        AudioSource[] sounds = GetComponents<AudioSource>();
        jumpSound = sounds[0]; //Connect jumpSound audio to Player
        coinSound = sounds[1]; //Connect coinSound audio to Player

        //Set isGrounded initially to true upon start
        isGrounded = true;

    }
    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {

            //Set jumpRequested to true when w key is pressed
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

    void FixedUpdate()
    {

        //horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Convert input into a target speed
        float targetSpeed = moveHorizontal * speed;

        //Smooth movement system - move object up to target speed by 15%
        //Lerp used to pull back towards the cap
        float newXPosition = Mathf.Lerp(rb.linearVelocity.x, targetSpeed, 0.15f);

        //Apply velocity (where x position is set at lerp
        rb.linearVelocity = new Vector2(newXPosition, rb.linearVelocity.y);

        if (jumpRequested && isGrounded)
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpSound.Play(); //When the Player jumps, play jumpSound
            jumpRequested = false; //Reset jumpRequested so Player can't infinately jump

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

            //If touching the Ground layer, set isGrounded to true
            isGrounded = true;
            Debug.Log("Grounded is true");

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Speed changers (speed set in gameObject)

        //speedBoost
        if (collision.gameObject.CompareTag("speedBoost"))
        {

            //Increase speed specified amount upon collision with speedIncrease isTrigger GameObject
            speed += speedIncrease;

        }

        //speedDecrease
        if (collision.gameObject.CompareTag("speedDecrease"))
        {

            //Decrease speed specified amount upon collision with speedIncrease isTrigger GameObject
            speed -= speedDecrease;

        }

        //Coin
        if (collision.gameObject.CompareTag("Coin"))
        {

            //Play coin sound upon isTrigger collision
            coinSound.Play();
            Destroy(collision.gameObject); //Destroy GameObject upon isTrigger collision

        }

        //Jumper
        if (collision.gameObject.CompareTag("Jumper"))
        {

            //Set insideJumper to true when active, allowing for jump
            insideJumper = true;

        }

        if (collision.gameObject.CompareTag("Bouncer") && isGrounded)
        {

            //When the Player interacts with this, they will launch up
            rb.AddForce(Vector2.up * (jumpForce + 8), ForceMode2D.Impulse);

        }

        if (collision.gameObject.CompareTag("Bouncer") && !isGrounded)
        {

            //When the Player interacts with this, they will launch up
            //Launch is decreased since Player jump and bouncer boost may stack together
            rb.AddForce(Vector2.up * (jumpForce + 2), ForceMode2D.Impulse);

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {

        Debug.Log("Collision");
        if (collision.gameObject.layer == 8)
        {

            //Set isGrounded to false when exiting ground, disallowing a jump
            isGrounded = false;
            Debug.Log("Grounded is false");

            jumpRequested = false;

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Jumper"))
        {

            //After Player has left Jumper GameObject, reset everything
            insideJumper = false;
            jumpCount = 0;

        }

    }

}

