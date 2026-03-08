using System.Collections;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public float health;
    public float moveSpeed;
    public GameObject currentBullet;
    public float cooldownModifier = 0f;
    public float damageModifier = 0f;
    public Color flashColor;
    public float flashDuration = 0.11f;

    public void SetHealth(float amount, string type)
    {
        switch (type.ToLower())
        {
            case "damage":
                health -= amount;
                break;
            case "heal":
                health += amount;
                break;
            default:
                health += 0;
                print("Parameter for Health Type must be either damage or heal");
                break;
        }
    }

    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void FlashSprite()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;
        StartCoroutine(Flash(spriteRenderer, originalColor));
    } 
    
    IEnumerator Flash(SpriteRenderer spriteRenderer, Color originalColor)
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
        yield return new WaitForSeconds(flashDuration);
    }
}
