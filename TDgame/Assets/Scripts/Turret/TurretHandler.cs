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
        Transform closestEnemy = tc.GetClosestEnemy();
        if (closestEnemy != null)
        {
            ta.SetTarget(closestEnemy);
            ts.Shoot();
        }
    }
}
