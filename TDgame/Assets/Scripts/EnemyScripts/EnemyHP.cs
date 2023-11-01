using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float hp = 100;
    public GameObject bullet;
    public SpriteRenderer spriteRenderer;
    public MetalHandler metal;
    private Color originalColor;

    void Start()
    {
        GameObject metalObject = GameObject.FindGameObjectWithTag("MenuHandler");
        if (metalObject != null)
        {
            metal = metalObject.GetComponent<MetalHandler>();
        }
        originalColor = spriteRenderer.color;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= 15;
            metal.metal += 3;

            StartCoroutine(FlashRed());
        }
    }

    void Update()
    {
        if (hp <= 0)
        {
            metal.metal += 5;
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
