using UnityEngine;

public class winTrigger : MonoBehaviour
{

    //Add gameWinUI to be triggered on isTrigger collision from Player to GameObject
    public GameObject gameWinUI;

    void Start()
    {

        //Set game to start (when loaded into new scenes, it's initially paused)
        Time.timeScale = 1f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") || collision.CompareTag("Ship"))
        {

            //Pause active screen
            Time.timeScale = 0f;

            //Set gameWinUI to appear when Player collides with winTrigger GameObject
            gameWinUI.SetActive(true);

        }

        else
        {

            //If the Player-controlled GameObject has not interacted with winTrigger

            gameWinUI.SetActive(false); //Set gameWinUI to inactive
            Time.timeScale = 1f; //Keep active scene running

        }

    }

}