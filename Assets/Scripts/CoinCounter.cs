using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Keeps track of the number of coins the player has picked up. Displays this information on the screen.
/// </summary>
public class CoinCounter : MonoBehaviour
{
    /// <summary>
    /// The slider to adjust.
    /// </summary>
    private static Slider slider;

    /// <summary>
    /// The text to adjust.
    /// </summary>
    private static TextMeshProUGUI text;

    /// <summary>
    /// Initializes the slider and text fields.
    /// </summary>
    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        UpdateUI();
    }

    /// <summary>
    /// Add's the argued increment to the coin count.
    /// </summary>
    /// <param name="increment">The number to add to the coin count</param>
    public static void IncreaseCoinCount(int incremenet)
    {
        int coinCount = (int)slider.value + incremenet;
        if (coinCount >= slider.maxValue)
        {
            LifeCounter.AddLife();
            coinCount = coinCount % (int)slider.maxValue;
        }
        PlayerPrefs.SetInt("coinCount", coinCount);
        UpdateUI();
    }

    /// <summary>
    /// Sets the UI elements (slider and text) to match the current coinCount.
    /// </summary>
    private static void UpdateUI()
    {
        int coinCount = PlayerPrefs.GetInt("coinCount");
        slider.value = coinCount;
        text.text = coinCount.ToString();
    }
}
