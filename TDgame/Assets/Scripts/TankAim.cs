using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAim : MonoBehaviour
{
    public Transform turret;
    public Transform tankgun;
    public bool canAim;

    private void Start()
    {
        turret = GameObject.FindWithTag("Turret").transform;
        canAim = true;
    }


    void Update()
    {
        tankgun.transform.right = turret.position - tankgun.transform.position;
    }
}
