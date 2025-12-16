using UnityEngine;

public class triggerExitDestroyer : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") || collision.CompareTag("Ship"))
        {

            Destroy(gameObject);

        }

    }

}
