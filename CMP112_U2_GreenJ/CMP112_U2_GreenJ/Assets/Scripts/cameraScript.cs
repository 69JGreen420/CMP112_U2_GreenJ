using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public Transform Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector3(Player.position.x + 3, Player.position.y, -10);

    }
}
