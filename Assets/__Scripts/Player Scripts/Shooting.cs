using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Variables
    [SerializeField] private float bulletSpeed = 6.0f;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float firingInterval = 0.1f;
    [SerializeField] private AudioClip shootClip;

    private GameObject bulletParent;

    private Coroutine firingCoroutine;  // pointer to the coroutine
                                        // need this to stop firing

    private void Start()
    {
        bulletParent = GameObject.Find("BulletParent");
        if (!bulletParent)
        {
            bulletParent = new GameObject("BulletParent");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // setup a co routine to fire the bullets - start firing
            firingCoroutine = StartCoroutine(FireCoroutine());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // stop firing
            StopCoroutine(firingCoroutine);
        }
    }

    // coroutine must be of type IEnumerator
    private IEnumerator FireCoroutine()
    {
        while (true)
        {
            // generate bullets
            Bullet bullet = Instantiate(bulletPrefab, bulletParent.transform);
            bullet.transform.position = transform.position;
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();

            // Play shooting audio clip
            AudioSource.PlayClipAtPoint(shootClip, transform.position);

            rbb.velocity = Vector2.right * bulletSpeed;
            // the yield return, causes the method to pause
            // sleep()
            yield return new WaitForSeconds(firingInterval);
        }
    }
}
