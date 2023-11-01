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
    public Animator animator;
    void Start()
    {
        canShoot = true;
        animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            Fire();
            if (nextbullet > 0)
            {
                nextbullet -= Time.deltaTime;
            }
        }
    }

    void Fire()
    {
        if (nextbullet > 0)
        {
            return;
        }

        Instantiate(bullet, firePoint.position, firePoint.rotation);
        nextbullet = nextBulletTime;
        animator.SetTrigger("Shoot");

        shootAudioSource.Play();
    }
}
