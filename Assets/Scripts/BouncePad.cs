using UnityEngine;

/// <summary>
/// The platform that this script is attatched to will bounce the player upon collision.
/// </summary>
public class BouncePad : MonoBehaviour
{
    /// <summary>
    /// Bounces the player upon collision.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D other)
    {
        Bounce(other.gameObject);
    }

    /// <summary>
    /// Applies a force to the player.
    /// The direction of the force is determined by the player's position relative to this platform.
    /// For example, if the player is to the left of this platform, the player will be bounced to the left.
    /// </summary>
    /// <param name="player">The GameObject to apply a force to.</param>
    private void Bounce(GameObject player)
    {
        Vector2 bounceForce = new Vector2(7500, 2500);
        Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(DetermineDirection() * bounceForce);
        rigidbody.AddForce(Vector2.up * bounceForce);
    }

    /// <summary>
    /// Determines the relative position of the player and returns the result.
    /// </summary>
    /// <returns>
    /// The vector2 representative of the player's position relative to this platform or
    /// Vector2.zero if the player's collider cannot be found from a boxcast.
    /// </returns>
    private Vector2 DetermineDirection()
    {
        Vector2[] directions = { Vector2.left, Vector2.right, Vector2.up, Vector2.down };
        foreach (Vector2 direction in directions)
        {
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            if (boxCollider.Cast(direction, new RaycastHit2D[1], 0.01f) > 0)
            {
                return direction;
            }
        }
        return Vector2.zero;
    }
}
