using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHandler : MonoBehaviour
{
    private TurretCollider tc;
    private TurretAim ta;
    private TurretShoot ts;

    private void Start()
    {
        tc = GetComponent<TurretCollider>();
        ta = GetComponent<TurretAim>();
        ts = GetComponent<TurretShoot>();
    }

    void Update()
    {
        Debug.Log("help");
        if (tc.enemyInRange)
        {
            ta.Aim();
            ts.Shoot();
            Debug.Log("enemy is targetable");
        }
    }
}
