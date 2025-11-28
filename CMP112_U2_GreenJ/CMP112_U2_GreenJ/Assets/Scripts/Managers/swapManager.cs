using UnityEngine;

public class swapManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject Ship;

    public cameraScript cameraScript;

    public void swapToShip(Vector3 spawnPosition)
    {

        Player.SetActive(false);

        Ship.transform.position = spawnPosition;
        Ship.SetActive(true);

        cameraScript.SetTarget(Ship);

    }

    public void swapToPlayer(Vector3 spawnPosition)
    {

        var playerMove = Player.GetComponent<playerMovement>();
        playerMove.setIsGrounded(true);

        Ship.SetActive(false);

        Player.transform.position = spawnPosition;
        Player.SetActive(true);

        cameraScript.SetTarget(Player);

    }

}
