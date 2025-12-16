using UnityEngine;

public class cameraScript : MonoBehaviour
{

    //Set target to active Player-controlled GameObject
    public Transform target;

    //LateUpdeate always used for camera scripts
    void LateUpdate()
    {

        //If a GameObject target (Player or Ship is found)
        if (target != null)
        {

            //Set camera offset
            transform.position = new Vector3(target.position.x + 5, target.position.y, -10);

        }

    }

    //Create SetTarget function, calling in a GameObject parameter (for target switching)
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