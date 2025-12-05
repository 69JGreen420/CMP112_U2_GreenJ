using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{

    public GameManager GameManager;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {



    }

    public void loadNextLevel()
    {

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);

    }

    //Update is called once per frame
    void Update()
    {
        
    }
}
