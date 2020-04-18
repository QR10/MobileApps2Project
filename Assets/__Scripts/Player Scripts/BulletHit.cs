using UnityEngine;

public class BulletHit : MonoBehaviour
{
    // Variables
    [SerializeField] private AudioClip hitClip;

    // If the bullet hit's an enemy, desactivate the enemy and destroy the bullet
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            // Play hit sound
            AudioSource.PlayClipAtPoint(hitClip, transform.position);

            Destroy(gameObject);
            target.gameObject.SetActive(false);
        }
    }

    // If bullet hits Dispawner destroy the bullet
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Dispawner")
        {
            Destroy(gameObject);
        }
    }
}
