using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A script controlling the player's respawn behaviours.
/// </summary>
public class PlayerRespawn : MonoBehaviour
{
    /// <summary>
    /// Moves the player to their respawn point.
    /// </summary>
    private void Start()
    {
        transform.position = GetRespawnPoint();
    }

    /// <summary>
    /// Sets the player's respawn point to the argued Vector3.
    /// </summary>
    /// <param name="respawnPoint">The Vector3 to set the player's respawn point to.</param>
    public static void SetRespawnPoint(Vector3 respawnPoint)
    {
        PlayerPrefs.SetFloat("x", respawnPoint.x);
        PlayerPrefs.SetFloat("y", respawnPoint.y);
        PlayerPrefs.SetFloat("z", respawnPoint.z);
    }

    /// <returns>The player's respawn point</returns>
    public static Vector3 GetRespawnPoint()
    {
        float x = PlayerPrefs.GetFloat("x");
        float y = PlayerPrefs.GetFloat("y");
        float z = PlayerPrefs.GetFloat("z");
        return new Vector3(x, y, z);
    }

    /// <summary>
    /// Reloads the active scene therein respawning the player.
    /// </summary>
    public static void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
