using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public BaseStats baseStats;
    private Projectile bulletScript;
    public Transform bulletSpawner;

    private InputAction shoot;
    private bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletScript = baseStats.currentBullet.GetComponent<Projectile>();
    }

    void Update()
    {
        if (shoot != null && shoot.IsPressed() && canShoot)
        {
            Instantiate(baseStats.currentBullet, bulletSpawner.position, bulletSpawner.rotation);
            StartCoroutine(ShootCooldown());
        }
        
        if (baseStats.health <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        moveInput.Normalize();
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        shoot = context.action;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * baseStats.moveSpeed;
    }

    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(bulletScript.projectileCooldown - baseStats.cooldownModifier);
        canShoot = true;
    }
}