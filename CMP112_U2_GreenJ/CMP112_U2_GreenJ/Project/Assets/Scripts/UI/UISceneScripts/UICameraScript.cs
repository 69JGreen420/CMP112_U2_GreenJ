using UnityEngine;

public class UICameraScript : MonoBehaviour
{

    //Set target to active Player-controlled GameObject
    public Transform target;

    //LateUpdeate always used for camera scripts
    void LateUpdate()
    {

        //Camera offset
        transform.position = new Vector3(target.position.x, target.position.y + 4, -10);

    }

}