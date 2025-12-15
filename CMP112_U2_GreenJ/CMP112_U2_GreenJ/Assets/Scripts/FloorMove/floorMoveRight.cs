using UnityEngine;

public class floorMoveRight : MonoBehaviour
{

    public float distance;
    public float speed;

    private float startPosition;
    private bool movingRight = true;
    private bool movingLeft = false;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Record GameObject's initial y position and store it as centre point
        startPosition = transform.position.x;

    }

    //Update is called once per frame
    void Update()
    {

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

        if (movingLeft)
        {

            //Move object to the left at set speed
            transform.position += Vector3.left * speed * Time.deltaTime;

            //If the object has reached its max distance it can travel to the right
            if (transform.position.x <= startPosition - distance)
            {

                movingLeft = false; //Set movingLeft to false (can't move any further left)
                movingRight = true; //Set movingRight to true (allowing object to now move right)

            }

        }

    }

}
