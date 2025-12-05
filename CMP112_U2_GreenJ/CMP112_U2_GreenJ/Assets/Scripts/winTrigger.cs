using UnityEngine;

public class winTrigger : MonoBehaviour
{

    //Add gameWinUI to be triggered on isTrigger collision from Player to GameObject
    public GameObject gameWinUI;

    void Start()
    {

        Time.timeScale = 1f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            //Pause gameplay
            Time.timeScale = 0f;

            gameWinUI.SetActive(true);

        }

        else
        {

            gameWinUI.SetActive(false);

        }

    }
} 