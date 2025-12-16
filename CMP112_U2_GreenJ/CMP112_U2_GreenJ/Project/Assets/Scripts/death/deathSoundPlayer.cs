using UnityEngine;

public class deathSoundPlayer : MonoBehaviour
{

    //Singleton instance - allowing any other script to call
    public static deathSoundPlayer Instance;
    AudioSource deathSound;

    void Awake()
    {

        if (Instance == null)
        {

            //Set instance to itself (deathSoundPlayer)
            Instance = this;

        }

        else
        {

            //If there are any other instances, destroy the object, allowing for only one sound to play
            Destroy(gameObject);
            return;

        }

    }

    void Start()
    {

        deathSound = GetComponent<AudioSource>();

    }

    public void playDeathSound()
    {

        //When called, play death sound
        deathSound.Play();

    }

}
