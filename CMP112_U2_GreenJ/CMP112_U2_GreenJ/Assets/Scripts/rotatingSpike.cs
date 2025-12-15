using UnityEngine;

public class rotatingSpike : MonoBehaviour
{

    //Set rotationSpeed in degrees per second
    public float rotationSpeed;

    void Update()
    {

        //Rotate the Spike GameObject around specified rotation speed
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

    }

}