using UnityEngine;

public class floorMoveDown : MonoBehaviour
{

    public float distance;
    public float speed;

    private float startPosition;
    private bool movingUp = true;
    private bool movingDown = false;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Set initial startPosition to be same as GameObject position
        startPosition = transform.position.y;

    }

    //Update is called once per frame
    void Update()
    {

        if (movingDown)
        {

            //Move object to the left
            transform.position += Vector3.up * speed * Time.deltaTime;

            if (transform.position.y >= startPosition + distance)
            {

                movingDown = false;
                movingUp = true;

            }

        }

        if (movingUp)
        {

            transform.position += Vector3.down * speed * Time.deltaTime;

            if (transform.position.y <= startPosition - distance)
            {

                movingUp = false;
                movingDown = true;

            }


        }

    }
}
