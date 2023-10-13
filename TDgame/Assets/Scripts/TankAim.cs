using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAim : MonoBehaviour
{
    public Transform enemies;
    public Transform turret;
    public bool canAim;

    private void Start()
    {
        enemies = GameObject.FindWithTag("Enemy").transform;
        canAim = true;
    }


    void Update()
    {
        turret.transform.up = enemies.position - turret.transform.position;
    }
}
