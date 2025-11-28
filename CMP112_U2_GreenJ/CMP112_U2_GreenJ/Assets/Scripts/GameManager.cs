using UnityEngine;
using UnityEngine.SceneManagement; // Important for scene management

public class GameManager : MonoBehaviour
{
    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}