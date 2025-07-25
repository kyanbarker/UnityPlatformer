using UnityEngine;

/// <summary>
/// The GameObject that this script is attatched to will begin carrying the player on collision.
/// They will stop when the player leaves collision.
///
/// The behaviours of this script were originally implemented in AutoMovement.
/// A bug arose when the player collided with an automoving bounce pad. The AutoMovement script
/// childed the player to the bounce pad, and the Disappearer script destroyed the bounce pad and by proxy
/// the childed player.
/// </summary>
public class CarryPlayer : MonoBehaviour
{
    /// <summary>
    /// Invoked when the player collides with this platform. This platform begins to carry the player.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.parent = this.transform;
    }

    /// <summary>
    /// Invoked when the player leaves this platform. This platform stops carrying the player.
    /// </summary>
    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.parent = null;
    }
}
