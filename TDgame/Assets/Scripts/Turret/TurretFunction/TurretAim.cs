using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAim : MonoBehaviour
{
    private Transform target;
    public GameObject TurretRot;

    private void Update()
    {
        if (target != null)
        {
            TurretRot.transform.up = target.position - TurretRot.transform.position;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}