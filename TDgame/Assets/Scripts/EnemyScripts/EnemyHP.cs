using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int hp = 100;
    public GameObject bullet;
    public SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        originalColor = spriteRenderer.color;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= 15;

            StartCoroutine(FlashRed());
        }
    }

    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = originalColor;
    }
}
