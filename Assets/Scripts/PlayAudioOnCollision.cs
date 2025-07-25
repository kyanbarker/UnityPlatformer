using UnityEngine;

/// <summary>
/// Plays an audio clip on collision.
/// </summary>
public class PlayAudioOnCollision : MonoBehaviour
{
    /// <summary>
    /// The audio clip to play on collision.
    /// </summary>
    public AudioClip audioClip;

    /// <summary>
    /// Invoked when the player collides with this game object. Plays the audio clip.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }

    /// <summary>
    /// Invoked when the player collides with this game object. Plays the audio clip.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D other)
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
}
