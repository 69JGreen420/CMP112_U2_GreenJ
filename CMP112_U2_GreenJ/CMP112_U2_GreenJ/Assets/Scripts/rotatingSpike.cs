using UnityEngine;

public class rotatingSpike : MonoBehaviour
{
    public float rotationSpeed; //degrees per second

    void Update()
    {

        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

    }
}