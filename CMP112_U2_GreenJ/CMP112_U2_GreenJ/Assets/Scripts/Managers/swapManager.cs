using UnityEngine;

public class swapManager : MonoBehaviour
{

    //Player controlled GameObject's
    public GameObject Player;
    public GameObject Ship;

    //Call in cameraScript so camera size change can happen
    public cameraScript cameraScript;

    public void swapToShip(Vector3 spawnPosition)
    {

        //Turn Player off
        Player.SetActive(false);

        //Replace the Player with the Ship at the Player's last position
        Ship.transform.position = spawnPosition;

        //Make ship visible
        Ship.SetActive(true);

        //Change camera target to Ship
        cameraScript.SetTarget(Ship);

        //When GameObject is switched to Ship, decrease camera size
        cameraScript.SetCameraSize(7f);

    }

    public void swapToPlayer(Vector3 spawnPosition)
    {

        //Call in PlayerMovement script so Player can move
        var playerMove = Player.GetComponent<playerMovement>();

        //Reset Player to be grounded
        playerMove.setIsGrounded(true);

        //Turn Ship off
        Ship.SetActive(false);

        //Replace the Ship with the Player at the Ship last position
        Player.transform.position = spawnPosition;

        //Make Player visible
        Player.SetActive(true);

        //Change camera target to Player
        cameraScript.SetTarget(Player);

        //When GameObject is switched to Player, increase camera size
        cameraScript.SetCameraSize(8f);

    }

}
