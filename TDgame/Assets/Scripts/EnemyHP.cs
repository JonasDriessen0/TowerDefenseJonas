using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int hp = 100;
    public GameObject bullet;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("enemy hit");
            hp -= 15;
        }
    }

    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
