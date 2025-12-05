using UnityEngine;

public class death : MonoBehaviour
{

    public GameObject GameManager;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (GameManager != null)
        {

            //Initially make GameManager inactive until called
            GameManager.SetActive(false);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Destroy active GameObject when they reach deathBarrier or Spike collision
        if (collision.gameObject.CompareTag("deathBarrier") || collision.gameObject.CompareTag("Spike"))
        {

            die();

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Destroy active GameObject when they reach isTrigger collision of deathBarrier 
        if (collision.gameObject.CompareTag("deathBarrier"))
        {

            die();

        }

    }

    void die() {

        if (GameManager != null)
        {

            //When the active GameObject collides, activate GameManger (I.E turn on gameOverUI)
            GameManager.SetActive(true);

        }

        //Destroy active gameObject
        Destroy(gameObject);
        Debug.Log("Player died!");


    }

}
