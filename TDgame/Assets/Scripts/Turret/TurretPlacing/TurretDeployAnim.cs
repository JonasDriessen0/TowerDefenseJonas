using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDeployAnim : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("TurretDeploy");

    }
}
