using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollider : MonoBehaviour
{
    public bool enemyInRange = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyInRange = true;
            Debug.Log("Het werukt");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyInRange = false;
        }
    }
}
