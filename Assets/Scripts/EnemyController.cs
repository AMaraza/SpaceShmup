using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;

    public BaseStats baseStats;

    private bool canShoot = true;
    private Projectile bulletScript;

    public Transform bulletSpawner;

    public LayerMask wallMask;
    public LayerMask bulletMask;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletScript = baseStats.currentBullet.GetComponent<Projectile>();
    }

    // Update is called once per frame
    void Update()
    {
        if (baseStats.health <= 0)
        {
            Destroy(gameObject);
        }

        if (canShoot)
        {
            Instantiate(baseStats.currentBullet, bulletSpawner.position, bulletSpawner.rotation);
            StartCoroutine(ShootCooldown());
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(baseStats.moveSpeed * -1, 0);
    }
    
    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(bulletScript.projectileCooldown - baseStats.cooldownModifier);
        canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((wallMask.value & (1 << other.gameObject.layer)) > 0)
        {
            Destroy(gameObject);
        }
    }
}
