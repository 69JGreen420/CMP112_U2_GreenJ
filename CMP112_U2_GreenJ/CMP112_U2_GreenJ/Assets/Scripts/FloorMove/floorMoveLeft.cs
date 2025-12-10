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

        //Set initial startPosition to be same as GameObject position
        startPosition = transform.position.x;

    }

    //Update is called once per frame
    void Update()
    {

        if (movingLeft)
        {

            //Move object to the left
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (transform.position.x <= startPosition - distance)
            {

                movingLeft = false;
                movingRight = true;

            }


        }

        if (movingRight)
        {

            transform.position += Vector3.right * speed * Time.deltaTime;

            if (transform.position.x >= startPosition + distance)
            {

                movingRight = false;
                movingLeft = true;

            }

        }

    }
}
