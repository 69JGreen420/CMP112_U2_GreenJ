using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{

    //Call GameManager to interact with script
    public GameManager GameManager;

    public void loadNextLevel()
    {

        //Load next scene in list when called
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);

    }

}
