using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Variables
    [SerializeField] float speed = -3f;
    [SerializeField] float acceleration = -2f;

    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D> ();
        // Move objects
        myBody.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Speed up the obstacles gradually
        speed += Time.deltaTime * acceleration;
        
        // Move objects
        myBody.velocity = new Vector2(speed, 0);
    }
}
