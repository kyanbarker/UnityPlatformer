using UnityEngine;

/// <summary>
/// Increases the player's coin count on collision.
/// </summary>
public class Coin : MonoBehaviour
{
    /// <summary>
    /// The number to add to the coin count when the player collides with this coin.
    /// </summary>
    public int incremenet;

    /// <summary>
    /// Increases the player's coin count.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        CoinCounter.IncreaseCoinCount(incremenet);
    }
}
