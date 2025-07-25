using System.Collections;
using UnityEngine;

/// <summary>
/// The GameObject that this script is attatched to will kill the player upon collision.
/// </summary>
public class Lethal : MonoBehaviour
{
    /// <summary>
    /// Invoked when the player collides with this GameObject. The player is killed.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D other)
    {
        LifeCounter.RemoveLife();
        StartCoroutine(Kill(other.gameObject));
    }

    /// <summary>
    /// Kills the player.
    /// </summary>
    /// <param name="player">The GameObject to kill.</param>
    private IEnumerator Kill(GameObject player)
    {
        Destroy(player);
        yield return new WaitForSeconds(1);
        PlayerRespawn.Respawn();
    }
}
