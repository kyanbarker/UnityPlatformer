using static Utility;
using UnityEngine;

/// <summary>
/// A script controlling the player's movement.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// The Rigidbody2D of the player.
    /// </summary>
    private new Rigidbody2D rigidbody;

    /// <summary>
    /// The BoxCollider2D of the player.
    /// </summary>
    private BoxCollider2D boxCollider;

    /// <summary>
    /// The sprite of the player when they can dash.
    /// </summary>
    public Sprite dashSprite;

    /// <summary>
    /// The sprite of the player when they cannot dash.
    /// </summary>
    public Sprite normalSprite;

    /// <summary>
    /// The force to apply to the player when they walk.
    /// </summary>
    private float walkForce = 7000;

    /// <summary>
    /// The force to apply to the player when they dash.
    /// </summary>
    private float dashForce = 175;

    /// <summary>
    /// The force to apply to the player when they jump. Contains both an x and y force. The x force is only applied if the player is on a wall therein creating a wall jump.
    /// </summary>
    private Vector2 jumpForce = new Vector2(50, 75);

    /// <summary>
    /// True if the player can dash and false otherwise.
    /// </summary>
    public bool canDash = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    /// <summary>
    /// Updates the player's sprite based off whether or not they can dash.
    /// Moves the player based off of their input.
    /// </summary>
    private void Update()
    {
        UpdateSprite();
        Move();
    }

    /// <summary>
    /// Moves the player with respect to their inputs.
    /// </summary>
    private void Move()
    {
        Walk();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded(this.gameObject))
            {
                Jump();
            }
            else if (IsOnWall())
            {
                Jump();
                WallJump();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) &&
            GetInputDirection().magnitude != 0 && canDash)
        {
            Dash();
        }
    }

    /// <summary>
    /// Adds a force on the x axis to the player equal to the product of their input direction, walkForce, and the time elapsed since the last frame.
    /// If the player is not making an input on the x axis, no force will be applied.
    /// </summary>
    private void Walk()
    {
        Vector2 force = new Vector2(GetInputDirection().x * walkForce * Time.deltaTime, 0);
        rigidbody.AddForce(force);
    }

    /// <summary>
    /// Sets the player's velocity on the y axis equal to jumpForce.y.
    /// </summary>
    private void Jump()
    {
        Vector2 velocity = rigidbody.velocity;
        velocity.y = jumpForce.y;
        rigidbody.velocity = velocity;
    }

    /// <summary>
    /// Sets the player's velocity on the x axis equal to the product of jumpForce.x and the wall's direction relative to the player.
    /// </summary>
    private void WallJump()
    {
        Vector2 velocity = rigidbody.velocity;
        velocity.x = jumpForce.x * GetWallDirection().x * -1;
        rigidbody.velocity = velocity;
    }

    /// <summary>
    /// Adds a force to the player equal to the product of the their input direction and dashForce.
    /// Sets canDash to false such that the player may not infinitely dash.
    /// </summary>
    private void Dash()
    {
        rigidbody.velocity = GetInputDirection().normalized * dashForce;
        canDash = false;
    }

    /// <summary>
    /// Determines if the player is on the wall and returns the result.
    /// </summary>
    /// <returns>True if the player is on the wall and false otherwise.</returns>
    private bool IsOnWall()
    {
        return GetWallDirection() != Vector2.zero;
    }

    /// <summary>
    /// Determines the position of the wall relative to the player and returns the result.
    /// </summary>
    /// <returns>
    /// Vector2.left if the wall is to the left of the player,
    /// Vector2.right if the wall is to the right of the player, or
    /// Vector2.zero if the wall is not in the immediate proximity of the player.
    /// </returns>
    private Vector2 GetWallDirection()
    {
        Vector2[] directions = { Vector2.left, Vector2.right };
        foreach (Vector2 direction in directions)
        {
            int results = boxCollider.Cast(direction, new RaycastHit2D[1], 0.1f);
            if (results > 0)
            {
                return direction;
            }
        }
        return Vector2.zero;
    }

    /// <returns>A Vector2 that represents the player's input.</returns>
    private Vector2 GetInputDirection()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    /// <summary>
    /// Sets the sprite of the player to dashSprite if they can dash or to normalSprite if they cannot.
    /// </summary>
    private void UpdateSprite()
    {
        GetComponent<SpriteRenderer>().sprite = canDash ? dashSprite : normalSprite;
    }
}
