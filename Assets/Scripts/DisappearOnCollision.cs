using UnityEngine;

/// <summary>
/// The GameObject that this script is attatched to will be destroyed a specified amount of seconds after a collision occurs.
/// </summary>
public class DisappearOnCollision : MonoBehaviour
{
    /// <summary>
    /// The time to wait after a collision before being destroyed.
    /// </summary>
    public float disappearanceDelay;

    /// <summary>
    /// Invoked when the player collides with this GameObject. This GameObject will be destroyed after the specified delay.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject, disappearanceDelay);
    }

    /// <summary>
    /// If the other collider belongs to the player, this GameObject will be destroyed after the specified delay.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject, disappearanceDelay);
    }
}
