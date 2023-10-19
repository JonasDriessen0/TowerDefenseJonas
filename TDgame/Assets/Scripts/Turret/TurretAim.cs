using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAim : MonoBehaviour
{
    public Transform enemies;
    public Transform turret;

    private void Start()
    {
        enemies = GameObject.FindWithTag("Enemy").transform;
    }


    public void Aim()
    {
        turret.transform.up = enemies.position - turret.transform.position;
    }
}
