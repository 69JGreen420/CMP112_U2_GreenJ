using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{

    //Call GameManager to interact with script
    public GameManager GameManager;


    public void LoadLevel1()
    {

        SceneManager.LoadScene("Level1");

    }

    public void LoadLevel2()
    {

        SceneManager.LoadScene("Level2");

    }

    public void LoadLevel3()
    {

        SceneManager.LoadScene("Level3");

    }

    public void LoadBonusLevel()
    {

        SceneManager.LoadScene("bonusLevel");

    }

    public void loadNextLevel()
    {

        //Load next scene in build profile when function is called
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);

    }

    public void loadGameStart()
    {

        SceneManager.LoadScene("gameStart");

    }

    public void loadGameWin()
    {

        SceneManager.LoadScene("gameWin");

    }

}
