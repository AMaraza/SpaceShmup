using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 2f;

    private bool canSpawn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            float randomY = UnityEngine.Random.Range(-4, 5);
            Instantiate(enemy, new Vector3(transform.position.x, randomY, 0), transform.rotation);
            StartCoroutine(SpawnCooldown());
        }

    }
    
    IEnumerator SpawnCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnRate);
        canSpawn = true;
    }
}

