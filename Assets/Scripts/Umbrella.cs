using static Utility;
using System.Collections;
using UnityEngine;

/// <summary>
/// Slows the descent of the player when being held by the player.
/// </summary>
public class Umbrella : MonoBehaviour
{
    /// <summary>
    /// The player GameObject.
    /// </summary>
    private GameObject player;

    /// <summary>
    /// The number to multiply the players gravity scale by when the player holds the umbrella.
    /// </summary>
    public float gravityDecrement;

    /// <summary>
    /// The rate at which the umbrella falls when it is not being held.
    /// </summary>
    public float gravityScale;

    /// <summary>
    /// The time for which the umbrella cannot be held after it has been dropped.
    /// </summary>
    public float holdCooldown;

    /// <summary>
    /// True if the umbrella can be held and false otherwise.
    /// </summary>
    private bool isHoldable = true;

    /// <summary>
    /// Intializes the reference to the player GameObject.
    /// </summary>
    private void Start()
    {
        player = GameObject.Find("Player");
    }

    /// <summary>
    /// Drops the umbrella if it is currently being held and the user presses left control.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && IsHeld())
        {
            Drop();
        }
    }

    /// <summary>
    /// Moves the umbrella down by gravityScale units if the umbrella is not being held and is not on the ground.
    /// </summary>
    private void FixedUpdate()
    {
        if (!IsHeld() && !IsGrounded(this.gameObject))
        {
            transform.position -= new Vector3(0, gravityScale, 0);
        }
    }

    /// <summary>
    /// Begins being held by the player if the player collides with the umbrella and the umbrella is holdable.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.isHoldable)
        {
            Hold();
        }
    }

    /// <summary>
    /// Stops following the player. Reverts the player's gravity to normal. Begins the hold cooldown.
    /// </summary>
    private void Drop()
    {
        transform.parent = null;
        player.GetComponent<Rigidbody2D>().gravityScale /= gravityDecrement;
        StartCoroutine(HoldCooldown());
    }

    /// <summary>
    /// Multiplies the player's gravity scale by gravityDecrement.
    /// Childs the umbrella to the player such that it maintains a constant relative position to the player.
    /// </summary>
    private void Hold()
    {
        player.GetComponent<Rigidbody2D>().gravityScale *= gravityDecrement;
        transform.parent = player.transform;
        transform.localPosition = new Vector3(0, 1, 1);
    }

    /// <summary>
    /// Prevents the umbrella from being held for a duration of holdCooldown seconds.
    /// </summary>
    private IEnumerator HoldCooldown()
    {
        isHoldable = false;
        yield return new WaitForSeconds(holdCooldown);
        isHoldable = true;
    }

    /// <returns>True if this umbrella is being held and false otherwise.</returns>
    private bool IsHeld()
    {
        return transform.parent != null;
    }
}
