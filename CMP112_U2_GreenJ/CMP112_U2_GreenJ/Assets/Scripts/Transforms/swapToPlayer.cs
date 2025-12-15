using UnityEngine;

public class swapToPlayer : MonoBehaviour
{

    //Call swapManager to interact with script
    public swapManager swapManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Ship"))
        {

            //When the Ship collides with transform GameObject, switch to Player GameObject
            //at the Ship's last position
            swapManager.swapToPlayer(collision.transform.position);

        }

    }

}
