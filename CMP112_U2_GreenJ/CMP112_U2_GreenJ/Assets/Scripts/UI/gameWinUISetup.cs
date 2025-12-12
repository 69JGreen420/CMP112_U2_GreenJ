using UnityEngine;

public class gameWinUISetup : MonoBehaviour
{
    void Awake()
    {

        //Ensure gameWinUI stays inactive when entering a new scene
        gameObject.SetActive(false);

    }
}
