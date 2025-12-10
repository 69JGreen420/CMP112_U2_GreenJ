using UnityEngine;

public class deathSoundPlayer : MonoBehaviour
{

    public static deathSoundPlayer Instance;
    AudioSource deathSound;

    void Awake()
    {

        if (Instance == null)
        {

            Instance = this;

        }

        else
        {

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

        //When called, play death sounds
        deathSound.Play();

    }

}
