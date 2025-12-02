using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void LateUpdate()
    {

        if (target != null)
        {

            transform.position = new Vector3(target.position.x + 5, target.position.y, -10);

        }

    }

    public void SetTarget(GameObject obj)
    {

        target = obj.transform;

    }
}
