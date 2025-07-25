using UnityEngine;

/// <summary>
/// A class containing general purpose utility methods to prevents rewriting of verbose code.
/// </summary>
public class Utility : MonoBehaviour
{
    /// <summary>
    /// Configures the physics system to ignore collisions between environmental objects.
    /// Collisions should only be recorded when a player collides with an environmental object.
    /// </summary>
    private void Start()
    {
        int defaultLayer = LayerMask.NameToLayer("Default");
        Physics2D.IgnoreLayerCollision(defaultLayer, defaultLayer);
    }

    /// <returns>True if there exist one or more colliders below the collider of the argued GameObject and false otherwise.</returns>
    /// <param name="gameObject">The GameObject to check for colliders below.</param>
    public static bool IsGrounded(GameObject gameObject)
    {
        Collider2D collider = gameObject.GetComponent<Collider2D>();
        int collidersBelow = collider.Cast(Vector2.down, new RaycastHit2D[1], 0.1f);
        return collidersBelow > 0;
    }

    /// <summary>
    /// Restarts the game.
    /// </summary>
    public static void Restart()
    {
        PlayerPrefs.DeleteAll();
        PlayerRespawn.Respawn();
    }
}
