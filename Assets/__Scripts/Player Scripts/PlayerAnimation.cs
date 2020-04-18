using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Variables
    private Animator anim;
 
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // When entering on a collision play the idle animation
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Obstacle")
        {
            anim.Play("Idle");
        }
    }

    // When exiting the collision play the run animation
    private void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.tag == "Obstacle")
        {
            anim.Play("Run");
        }
    }
}
