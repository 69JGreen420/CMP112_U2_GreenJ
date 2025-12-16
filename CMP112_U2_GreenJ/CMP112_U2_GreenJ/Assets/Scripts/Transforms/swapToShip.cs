using UnityEngine;

public class swapToShip : MonoBehaviour
{
    //Call swapManager to interact with script
    public swapManager swapManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            //When the Player collides with transform GameObject, switch to Ship GameObject
            //at the Player's last position
            swapManager.swapToShip(collision.transform.position);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            Destroy(gameObject);

        }

    }

}