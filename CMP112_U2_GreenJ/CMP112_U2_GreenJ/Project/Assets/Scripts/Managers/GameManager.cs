using UnityEngine;
using UnityEngine.SceneManagement; // Important for scene management

public class GameManager : MonoBehaviour
{

    public void RestartGame()
    {

        //When function is called, reload current scene
        //(Function is called inside restartButton button
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}