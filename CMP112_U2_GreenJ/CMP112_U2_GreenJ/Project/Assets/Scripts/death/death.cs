using UnityEngine;

public class death : MonoBehaviour
{

    //Include GameManager to connect gameOverUI to appear upon death
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Destroy active GameObject when they reach deathBarrier or Spike collision
        if (collision.gameObject.CompareTag("deathBarrier") || collision.gameObject.CompareTag("Spike"))
        {

            //Call death function when collision instance occurs
            die();

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Destroy active GameObject when they reach isTrigger collision of deathBarrier 
        if (collision.gameObject.CompareTag("deathBarrier"))
        {

            //Call death function when collision instance occurs
            die();

        }

    }

    void die() {

        if (GameManager != null)
        {

            //When the active GameObject collides, activate GameManger (I.E turn on gameOverUI)
            GameManager.SetActive(true);


        }

        if (deathSoundPlayer.Instance != null)
        {

            //Play death sound from deathSoundPlayer script
            //We do it seperately as otherwise, the sound would end when the GameObject is destroyed
            deathSoundPlayer.Instance.playDeathSound(); //Singleton pattern, only one instance allowed

        }

        //Destroy active gameObject
        Destroy(gameObject);
        Debug.Log("Active GameObject died!");


    }

}
