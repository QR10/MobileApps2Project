using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    // Variables
    public float speed = 0.1f;

    private Vector2 offset = Vector2.zero;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        // Get the material
        mat = GetComponent<Renderer>().material;
        // Set offset from the mat texture
        offset = mat.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += speed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offset);
    }
}
