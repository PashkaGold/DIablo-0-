using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spavner : MonoBehaviour
{
    public GameObject obj;
    private float randomX;
    Vector2 whereToSpawn;
    public float spawnDelay;
    float nextSpawn = 0.0f;

    private void Update()
    {
        if (Time.time > nextSpawn) 
        {
            nextSpawn = Time.time + spawnDelay;
            randomX = Random.Range(-8, 8);
            whereToSpawn = new Vector2(randomX, transform.position.y);
            GameObject Enemy = Instantiate(obj, whereToSpawn, Quaternion.identity);
            
        }
    }
}
