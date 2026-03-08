using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileForce = 100f;
    public float lifespan = 0.5f;
    public float projectileCooldown = 0.15f;
    public float baseDamage = 1f;

    private Rigidbody2D rb;

    public LayerMask layersToDetect;
    public LayerMask enemyLayer;
    public LayerMask playerLayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(projectileForce * transform.right.x, 0);

        Destroy(gameObject, lifespan);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((layersToDetect.value & (1 << other.gameObject.layer)) > 0)
        {
            Destroy(gameObject);
        }
        else if (transform.right.x < 0 && (playerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            BaseStats otherObject = other.gameObject.GetComponent<BaseStats>();
            otherObject.SetHealth(baseDamage, "damage");
            otherObject.FlashSprite();
            Destroy(gameObject);
        }
        else if (transform.right.x > 0 && (enemyLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            BaseStats otherObject = other.gameObject.GetComponent<BaseStats>();
            otherObject.SetHealth(baseDamage, "damage");
            otherObject.FlashSprite();
            Destroy(gameObject);
        }
    }
    
}
