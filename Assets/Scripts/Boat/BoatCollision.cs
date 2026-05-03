using UnityEngine;

public class BoatCollision : MonoBehaviour
{
    public BoatScoreController scoreController;

    public AudioSource audioSource;
    public AudioClip crashSound;

    private bool hasCollided = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasCollided) return;

        if (other.CompareTag("Iceberg"))
        {
            hasCollided = true;

            // reproducir sonido
            if (audioSource != null && crashSound != null)
            {
                audioSource.PlayOneShot(crashSound);
            }

            // perder
            scoreController.GameOver();
        }
    }
}