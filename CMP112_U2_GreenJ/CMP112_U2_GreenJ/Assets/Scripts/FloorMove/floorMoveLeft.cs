using UnityEngine;

public class floorMoveLeft : MonoBehaviour
{

    public float distance;
    public float speed;

    private float startPosition;
    private bool movingLeft = true;
    private bool movingRight = false;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Record GameObject's initial y position and store it as centre point
        startPosition = transform.position.x;

    }

    //Update is called once per frame
    void Update()
    {

        if (movingLeft)
        {

            //Move object to the left at set speed
            transform.position += Vector3.left * speed * Time.deltaTime;

            //If the object has reached its max distance it can travel to the left
            if (transform.position.x <= startPosition - distance)
            {

                movingLeft = false; //Set movingLeft to false (can't move any further left)
                movingRight = true; //Set movingRight to true (allowing object to now move right)

            }

        }

        //Move object to the right at set speed
        if (movingRight)
        {

            //Move object to the right at set speed
            transform.position += Vector3.right * speed * Time.deltaTime;

            //If the object has reached its max distance it can travel to the right
            if (transform.position.x >= startPosition + distance)
            {

                movingRight = false; //Set movingRight to false (can't move any further right)
                movingLeft = true; //Set movingLeft to true (allowing object to now move left)

            }

        }

    }
}
