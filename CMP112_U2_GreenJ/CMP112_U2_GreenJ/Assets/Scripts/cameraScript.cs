using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public Transform target;

    //LateUpdeate always used for camera scripts
    void LateUpdate()
    {

        if (target != null)
        {

            //Camera offset
            transform.position = new Vector3(target.position.x + 5, target.position.y, -10);

        }

    }

    //Create SetTarget function, calling in a GameObject parameter
    public void SetTarget(GameObject obj)
    {

        //Set Target to the current active GameObject
        target = obj.transform;

    }

    public void SetCameraSize(float newSize)
    {

        //Update cameraSize when needed
        Camera.main.orthographicSize = newSize;

    }

}
