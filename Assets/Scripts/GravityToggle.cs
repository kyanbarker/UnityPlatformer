using UnityEngine;

/// <summary>
/// When a player collides with a gravity toggle, the player's gravity is toggled.
/// </summary>
public class GravityToggle : MonoBehaviour
{
    /// <summary>
    /// Invoked when the player collides with this GameObject.
    /// The player's gravity is toggled, the player is turned upside down, and a debug raw is drawn.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        ToggleGravity(other.gameObject);
        TurnUpsideDown(other.gameObject);
        DrawGravityDirection(other.gameObject);
    }

    /// <summary>
    /// Draws a raw pointing in the direction of the player's gravity.
    /// </summary>
    /// <param name="player">The GameObject to draw the ray based off of.</param>
    private void DrawGravityDirection(GameObject player)
    {
        Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
        Vector3 direction = rigidbody.gravityScale > 0 ? Vector3.down : Vector3.up;
        Debug.DrawRay(transform.position, direction * 3, Color.green, 0.5f);
    }

    /// <summary>
    /// Toggles the gravity of the player.
    /// </summary>
    /// <param name="player">The GameObject to have their gravity toggled.</param>
    private void ToggleGravity(GameObject player)
    {
        Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
        rigidbody.gravityScale *= -1;
    }

    /// <summary>
    /// Turns the player upside down.
    /// </summary>
    /// <param name="player">The GameObject to be turned upside down.</param>
    private static void TurnUpsideDown(GameObject player)
    {
        Vector3 scale = player.transform.localScale;
        scale.y *= -1;
        player.transform.localScale = scale;
    }
}
