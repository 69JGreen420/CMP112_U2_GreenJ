using UnityEngine;

public class swapToShip : MonoBehaviour
{

    public swapManager swapManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            swapManager.swapToShip(collision.transform.position);

        }

    }

}