using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    /*
    Player Respawn:
    This script sends the player back to the respawn point
    when Respawn() is called.
    */

    public Transform respawnPoint;

    public void Respawn()
    {
        transform.position = respawnPoint.position;
    }
}