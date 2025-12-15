using UnityEngine;

public class floorMoveUp : MonoBehaviour
{

    public float distance;
    public float speed;

    private float startPosition;
    private bool movingUp = true;
    private bool movingDown = false;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Record GameObject's initial y position and store it as centre point
        startPosition = transform.position.y;

    }

    //Update is called once per frame
    void Update()
    {

        if (movingUp)
        {

            //Move object down at set speed
            transform.position += Vector3.up * speed * Time.deltaTime;

            //If the object has reached its minimum height
            if (transform.position.y >= startPosition + distance)
            {

                movingUp = false; //Set movingUp to false (can't move any further up)
                movingDown = true; //Set movingDown to true (allowing object to now move down)

            }

        }

        if (movingDown)
        {

            //Move object up at set speed
            transform.position += Vector3.down * speed * Time.deltaTime;

            //If the object has reached its max height
            if (transform.position.y <= startPosition - distance)
            {

                movingDown = false; //Set movingDown to false (can't move any further down)
                movingUp = true; //Set movingUp to true (allowing object to now move up)

            }

        }

    }

}
