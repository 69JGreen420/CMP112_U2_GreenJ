using UnityEngine;

public class gameWinUISetup : MonoBehaviour
{

    //Awake used to call function upon active state
    void Awake()
    {

        //Ensure gameWinUI stays inactive when entering a new scene
        gameObject.SetActive(false);

    }

}
