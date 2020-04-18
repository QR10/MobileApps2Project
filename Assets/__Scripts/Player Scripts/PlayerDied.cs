using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    // Variables
    [SerializeField] private AudioClip gameOverClip;
    
    public delegate void EndGame();
    public static event EndGame endGame;

    // Calls endGame event and destroys the player object
    void PlayerDiedEndGame() {
        if (endGame != null)
        {
            endGame();
        }

        Destroy(gameObject);
    }

    // If the player hits the dispawner call PlayerDiedEndGame
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Dispawner")
        {
            PlayerDiedEndGame();
        }
    }

    // If the player hits an enemy call PlayerDiedEndGame
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            // Play gameover clip
            AudioSource.PlayClipAtPoint(gameOverClip, transform.position);
            PlayerDiedEndGame();
        }
    }
}
