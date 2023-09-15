using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAim : MonoBehaviour
{
    [SerializeField] private Transform enemies;
    void Start()
    {
        transform.right = enemies.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = enemies.position - transform.position;
    }
}
