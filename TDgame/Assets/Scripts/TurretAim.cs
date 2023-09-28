using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAim : MonoBehaviour
{
    [SerializeField] private Transform enemies;
    public Transform turret;

    void Update()
    {
        turret.transform.up = enemies.position - turret.transform.position;
    }
}
