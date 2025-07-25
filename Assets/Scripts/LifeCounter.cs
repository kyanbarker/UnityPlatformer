using UnityEngine;
using TMPro;

/// <summary>
/// A script that manages the player's life count.
/// </summary>
public class LifeCounter : MonoBehaviour
{
    /// <summary>
    /// The text component to display the user's number of lives.
    /// </summary>
    private static TextMeshProUGUI text;

    /// <summary>
    /// If the player has no remaining lives, the game is restarted.
    /// For every life that the player is missing, the corresponding life GameObject's color is set to the disabled color.
    /// </summary>
    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        int lives = GetLives();
        if (lives == 0)
        {
            Utility.Restart();
        }
        UpdateText();
    }

    /// <summary>
    /// Displays the number of lives that the player has.
    /// </summary>
    private static void UpdateText()
    {
        text.text = GetLives().ToString();
    }


    /// <returns>The number of lives that the player has.</returns>
    private static int GetLives()
    {
        return PlayerPrefs.GetInt("lives", 5);
    }

    /// <summary>
    /// Invoked when the player dies. A life is removed from their life counter. If they have no more lifes remaining, the game restarts.
    /// </summary>
    public static void RemoveLife()
    {
        int lives = GetLives();
        PlayerPrefs.SetInt("lives", lives - 1);
        UpdateText();
    }

    /// <summary>
    /// Invoked when the player collects the maximum number of coins. A life is returned to the player.
    /// </summary>
    public static void AddLife()
    {
        int lives = GetLives();
        PlayerPrefs.SetInt("lives", lives + 1);
        UpdateText();
    }
}
