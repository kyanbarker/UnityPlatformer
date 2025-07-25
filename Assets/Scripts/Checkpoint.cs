using UnityEngine;

/// <summary>
/// The checkpoint that this script is attatched too sets the player's respawn point to this checkpoint's position upon collision.
/// </summary>
public class Checkpoint : MonoBehaviour
{
    /// <summary>
    /// Invoked when the player collides with this checkpoint. Sets the player's respawn point to the position of this checkpoint.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        SetRespawnPoint();
    }

    /// <summary>
    /// Sets the player's respawn point to the position of this checkpoint.
    /// </summary>
    public void SetRespawnPoint()
    {
        PlayerRespawn.SetRespawnPoint(transform.position);
    }
}
