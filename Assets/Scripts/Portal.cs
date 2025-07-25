using System.Collections;
using UnityEngine;

/// <summary>
/// The GameObject that this script is attatched to will, upon collision, teleport the player to its sibling portal.
/// </summary>
public class Portal : MonoBehaviour
{
    /// <summary>
    /// The number of seconds for which this teleport should be unable to teleport the player after having already done so.
    /// Constant (static and final) so that all portals have the same cooldown time.
    /// </summary>
    private const float cooldownTime = 2;

    /// <summary>
    /// True if this portal can teleport the player, false otherwise.
    /// </summary>
    private bool canTeleport = true;

    /// <summary>
    /// Invoked when the player collides with this portal.
    /// If portals can teleport, the player is teleported.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canTeleport)
        {
            Teleport(other.gameObject);
        }
    }

    /// <summary>
    /// Teleports the player to the other portal in this portal pair.
    /// Resets the player's velocity.
    /// This portal cools down for cooldown time.
    /// If the sibling GameObject is a portal, cooldown the sibling as well.
    /// </summary>
    /// <param name="player">The GameObject to teleport.</param>
    private void Teleport(GameObject player)
    {
        Transform sibling = GetOtherPortal();
        player.transform.position = sibling.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (sibling.TryGetComponent<Portal>(out Portal siblingPortal))
        {
            StartCoroutine(siblingPortal.Cooldown());
        }
        StartCoroutine(this.Cooldown());
    }

    /// <summary>
    /// Sets canTeleport to false for a duration of cooldownTime seconds. Then sets canTeleport back to true.
    /// </summary>
    public IEnumerator Cooldown()
    {
        canTeleport = false;
        yield return new WaitForSeconds(cooldownTime);
        canTeleport = true;
    }

    /// <summary>
    /// Invoked when the player collides with this portal.
    /// </summary>
    /// <returns>The other portal to teleport the player to.</returns>
    /// <exception cref="System.Exception">If this portal does not have a sibling portal to teleport the player to.</exception>
    private Transform GetOtherPortal()
    {
        Transform parent = transform.parent;
        int childCount = parent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (parent.GetChild(i) != this.transform)
            {
                return child;
            }
        }
        throw new System.Exception("This portal has no sibling portal to teleport the player to.");
    }
}
