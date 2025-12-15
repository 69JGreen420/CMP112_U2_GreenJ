using UnityEngine;

public class UICameraScript : MonoBehaviour
{

    public Transform target;

    //LateUpdeate always used for camera scripts
    void LateUpdate()
    {

            //Camera setup
            transform.position = new Vector3(target.position.x, target.position.y + 4, -10);


    }

}