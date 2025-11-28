using UnityEngine;

public class death : MonoBehaviour
{

    public GameObject GameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (GameManager != null)
        {

            GameManager.SetActive(false);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("deathBarrier") || collision.gameObject.CompareTag("Spike"))
        {

            die();

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("deathBarrier"))
        {

            die();

        }

    }

    void die() {

        if (GameManager != null)
        {

            GameManager.SetActive(true);

        }

        Destroy(gameObject);
        Debug.Log("Player died!");


    }

}
