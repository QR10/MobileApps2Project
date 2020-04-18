using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Calculating height of the quad (or Y scale) according to camera size
        var height = Camera.main.orthographicSize * 3f;
        // Calculating width size according to the screen size
        var width = height * Screen.width / Screen.height;

        // If is the background set the width and weight
        if (gameObject.name == "Background")
        {
            transform.localScale = new Vector3(width, height, 0);
        }
        // If is the ground set width but add more width for spawning obstacles later
        else
        {
            transform.localScale = new Vector3(width + 3f, 4, 0);
        }
    }
}
