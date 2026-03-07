using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public float health;
    public float moveSpeed;
    public GameObject currentBullet;
    public float cooldownModifier = 0f;
    public float damageModifier = 0f;
    

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
}
