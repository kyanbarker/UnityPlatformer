using UnityEngine;

/// <summary>
/// The dash crystal this script is attatched to will grant the player the ability to dash upon collision.
/// </summary>
public class DashCrystal : MonoBehaviour
{
    /// <summary>
    /// Invoked when the player collides with this dash crystal. Grants the player the ability to dash.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerMovement>().canDash = true;
    }
}
