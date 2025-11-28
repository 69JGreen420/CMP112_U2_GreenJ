using UnityEngine;

public class swapToPlayer : MonoBehaviour
{

    public swapManager swapManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Ship"))
        {

            swapManager.swapToPlayer(collision.transform.position);

        }

    }
}
