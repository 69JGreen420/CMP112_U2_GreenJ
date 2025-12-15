using UnityEngine;

public class winTrigger : MonoBehaviour
{

    //Add levelWinUI to be triggered on isTrigger collision from Player to GameObject
    public GameObject levelWinUI;

    void Start()
    {

        //Set game to start (when loaded into new scenes, it's initially paused)
        Time.timeScale = 1f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") || collision.CompareTag("Ship"))
        {

            //Pause gameplay
            Time.timeScale = 0f;

            //Set levelWinUI to appear when Player collides with winTrigger GameObject
            levelWinUI.SetActive(true);

        }

        else
        {

            levelWinUI.SetActive(false);
            Time.timeScale = 1f;

        }

    }
} 