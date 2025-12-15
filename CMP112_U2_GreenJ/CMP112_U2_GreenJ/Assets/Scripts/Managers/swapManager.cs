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

        //Deactivate Player GameObject
        Player.SetActive(false);

        //Move the Ship to where the Player last was
        Ship.transform.position = spawnPosition;

        //Make ship active - the user controls the Ship upon activation
        Ship.SetActive(true);

        //Change camera target to Ship
        cameraScript.SetTarget(Ship);

        //When GameObject is switched to Ship, increase camera size
        cameraScript.SetCameraSize(6f);

    }

    public void swapToPlayer(Vector3 spawnPosition)
    {

        //Call in PlayerMovement script so Player can move
        var playerMove = Player.GetComponent<playerMovement>();

        //Reset Player to initially be grounded (so Player isn't stuck to the ground)
        playerMove.setIsGrounded(true);

        //Deactivate Ship GameObject
        Ship.SetActive(false);

        //Move the Player to where the Ship last was
        Player.transform.position = spawnPosition;

        //Make Player active - the user controls the Player upon activation
        Player.SetActive(true);

        //Change camera target to Player
        cameraScript.SetTarget(Player);

        //When GameObject is switched to Player, decrease camera size
        cameraScript.SetCameraSize(4f);

    }

}
