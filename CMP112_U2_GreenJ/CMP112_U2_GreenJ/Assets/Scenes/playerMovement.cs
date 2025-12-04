using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    
    private bool isGrounded = false;
    private bool jumpRequested = false;
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

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>(); //Connect jumpSound audio to Player

    }

    void Update()
    {

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {

            jumpRequested = true;

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

            isGrounded = true;
            Debug.Log("Grounded is true");

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Speed changers (spped set in gameObject)

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