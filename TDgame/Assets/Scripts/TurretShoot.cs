using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public bool canShoot;
    private float nextbullet;
    public AudioSource shootAudioSource;
    public float nextBulletTime = 0.2f;
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        if (nextbullet > 0)
        {
            nextbullet -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        if (nextbullet > 0)
        {
            return;
        }

        Instantiate(bullet, firePoint.position, firePoint.rotation);
        nextbullet = nextBulletTime;

        // Play the audio clip
        shootAudioSource.Play();
    }
}
