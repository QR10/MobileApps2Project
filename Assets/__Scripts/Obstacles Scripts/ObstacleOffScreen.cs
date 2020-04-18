using UnityEngine;

public class ObstacleOffScreen : MonoBehaviour
{
    // If Obstacles hits Dispawner, desactivate the object
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Dispawner")
        {
            gameObject.SetActive(false);
        }   
    }
}
