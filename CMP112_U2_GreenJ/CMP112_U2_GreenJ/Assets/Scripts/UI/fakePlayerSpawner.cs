using UnityEngine;

public class fakePlayerSpawner : MonoBehaviour
{

    public GameObject fakePlayer;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Set random value from -5 to 5
        float randomX = Random.Range(-5f, 5f);
        //Set spawnPosition to randomnX value (x coord) along 3 in y coord
        Vector3 spawnPosition = new Vector3(randomX, 3f, 0f);

        //Spawn fakePlayer GameObject at runtime (Quaternion.identity used to keep orientation neutral
        Instantiate(fakePlayer, spawnPosition, Quaternion.identity);

    }

}
