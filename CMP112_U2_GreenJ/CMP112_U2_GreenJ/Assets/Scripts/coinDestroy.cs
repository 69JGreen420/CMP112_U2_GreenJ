/*using UnityEngine;

public class coinDestroy : MonoBehaviour
{

    AudioSource coinSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        coinSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //Cause the coin to disappear when a Player controlled object interacts with it
        if (gameObject.name == "Player" && gameObject.name == "Ship")
        {

            Destroy(gameObject);


        }

    }

}*/