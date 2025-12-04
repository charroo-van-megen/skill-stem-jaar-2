using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [Header("Optional Settings")]
    public AudioClip pickupSound; // sound when collected
    public float destroyDelay = 0f; // optional delay before destroying the coin

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only react to the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Play sound if assigned
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            // Destroy the coin
            Destroy(gameObject, destroyDelay);
        }
    }
}
